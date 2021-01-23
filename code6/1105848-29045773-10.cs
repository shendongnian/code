GraphicsDeviceService.cs
    #region File Description
    //-----------------------------------------------------------------------------
    // GraphicsDeviceService.cs
    //
    // Microsoft XNA Community Game Platform
    // Copyright (C) Microsoft Corporation. All rights reserved.
    //-----------------------------------------------------------------------------
    #endregion
    #region Using Statements
    using System;
    using System.Threading;
    using Microsoft.Xna.Framework.Graphics;
    #endregion
    // The IGraphicsDeviceService interface requires a DeviceCreated event, but we
    // always just create the device inside our constructor, so we have no place to
    // raise that event. The C# compiler warns us that the event is never used, but
    // we don't care so we just disable this warning.
    #pragma warning disable 67
    namespace XNATransparentWindow
    {
        /// <summary>
        /// Helper class responsible for creating and managing the GraphicsDevice.
        /// All GraphicsDeviceControl instances share the same GraphicsDeviceService,
        /// so even though there can be many controls, there will only ever be a single
        /// underlying GraphicsDevice. This implements the standard IGraphicsDeviceService
        /// interface, which provides notification events for when the device is reset
        /// or disposed.
        /// </summary>
        class GraphicsDeviceService : IGraphicsDeviceService
        {
            #region Fields
            // Singleton device service instance.
            static GraphicsDeviceService singletonInstance;
            // Keep track of how many controls are sharing the singletonInstance.
            static int referenceCount;
            #endregion
            /// <summary>
            /// Constructor is private, because this is a singleton class:
            /// client controls should use the public AddRef method instead.
            /// </summary>
            GraphicsDeviceService(IntPtr windowHandle, int width, int height)
            {
                parameters = new PresentationParameters();
                parameters.BackBufferWidth = Math.Max(width, 1);
                parameters.BackBufferHeight = Math.Max(height, 1);
                parameters.BackBufferFormat = SurfaceFormat.Vector4; // SurfaceFormat.Color;
                parameters.DeviceWindowHandle = windowHandle;
                parameters.PresentationInterval = PresentInterval.Immediate;
                parameters.IsFullScreen = false;
                graphicsDevice = new GraphicsDevice(GraphicsAdapter.DefaultAdapter, GraphicsProfile.Reach, parameters);
            }
            /// <summary>
            /// Gets a reference to the singleton instance.
            /// </summary>
            public static GraphicsDeviceService AddRef(IntPtr windowHandle,
                                                       int width, int height)
            {
                // Increment the "how many controls sharing the device" reference count.
                if (Interlocked.Increment(ref referenceCount) == 1)
                {
                    // If this is the first control to start using the
                    // device, we must create the singleton instance.
                    singletonInstance = new GraphicsDeviceService(windowHandle,
                                                                  width, height);
                }
                return singletonInstance;
            }
            /// <summary>
            /// Releases a reference to the singleton instance.
            /// </summary>
            public void Release(bool disposing)
            {
                // Decrement the "how many controls sharing the device" reference count.
                if (Interlocked.Decrement(ref referenceCount) == 0)
                {
                    // If this is the last control to finish using the
                    // device, we should dispose the singleton instance.
                    if (disposing)
                    {
                        if (DeviceDisposing != null)
                            DeviceDisposing(this, EventArgs.Empty);
                        graphicsDevice.Dispose();
                    }
                    graphicsDevice = null;
                }
            }
            /// <summary>
            /// Resets the graphics device to whichever is bigger out of the specified
            /// resolution or its current size. This behavior means the device will
            /// demand-grow to the largest of all its GraphicsDeviceControl clients.
            /// </summary>
            public void ResetDevice(int width, int height)
            {
                if (DeviceResetting != null)
                    DeviceResetting(this, EventArgs.Empty);
                parameters.BackBufferWidth = Math.Max(parameters.BackBufferWidth, width);
                parameters.BackBufferHeight = Math.Max(parameters.BackBufferHeight, height);
                graphicsDevice.Reset(parameters);
                if (DeviceReset != null)
                    DeviceReset(this, EventArgs.Empty);
            }
            /// <summary>
            /// Gets the current graphics device.
            /// </summary>
            public GraphicsDevice GraphicsDevice
            {
                get { return graphicsDevice; }
            }
            GraphicsDevice graphicsDevice;
            // Store the current device settings.
            PresentationParameters parameters;
            // IGraphicsDeviceService events.
            public event EventHandler<EventArgs> DeviceCreated;
            public event EventHandler<EventArgs> DeviceDisposing;
            public event EventHandler<EventArgs> DeviceReset;
            public event EventHandler<EventArgs> DeviceResetting;
        }
    }
ServiceContainer.cs
    #region File Description
    //-----------------------------------------------------------------------------
    // ServiceContainer.cs
    //
    // Microsoft XNA Community Game Platform
    // Copyright (C) Microsoft Corporation. All rights reserved.
    //-----------------------------------------------------------------------------
    #endregion
    #region Using Statements
    using System;
    using System.Collections.Generic;
    #endregion
    namespace XNATransparentWindow
    {
        /// <summary>
        /// Container class implements the IServiceProvider interface. This is used
        /// to pass shared services between different components, for instance the
        /// ContentManager uses it to locate the IGraphicsDeviceService implementation.
        /// </summary>
        public class ServiceContainer : IServiceProvider
        {
            Dictionary<Type, object> services = new Dictionary<Type, object>();
            /// <summary>
            /// Adds a new service to the collection.
            /// </summary>
            public void AddService<T>(T service)
            {
                services.Add(typeof(T), service);
            }
            /// <summary>
            /// Looks up the specified service.
            /// </summary>
            public object GetService(Type serviceType)
            {
                object service;
                services.TryGetValue(serviceType, out service);
                return service;
            }
        }
    }
ContentBuilder.cs
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.IO;
    using System.Diagnostics;
    using Microsoft.Build.Construction;
    using Microsoft.Build.Evaluation;
    using Microsoft.Build.Execution;
    using Microsoft.Build.Framework;
    namespace XNATransparentWindow
    {
        public class ContentBuilder : IDisposable
        {
            #region Fields
            // What importers or processors should we load?
            const string xnaVersion = ", Version=4.0.0.0, PublicKeyToken=842cf8be1de50553";
            static string[] pipelineAssemblies =
            {
                "Microsoft.Xna.Framework.Content.Pipeline.FBXImporter" + xnaVersion,
                "Microsoft.Xna.Framework.Content.Pipeline.XImporter" + xnaVersion,
                "Microsoft.Xna.Framework.Content.Pipeline.TextureImporter" + xnaVersion,
                "Microsoft.Xna.Framework.Content.Pipeline.EffectImporter" + xnaVersion,
                "Microsoft.Xna.Framework.Content.Pipeline.AudioImporters" + xnaVersion,
                "Microsoft.Xna.Framework.Content.Pipeline.VideoImporters" + xnaVersion,
                // If you want to use custom importers or processors from
                // a Content Pipeline Extension Library, add them here.
                //
                // If your extension DLL is installed in the GAC, you should refer to it by assembly
                // name, eg. "MyPipelineExtension, Version=1.0.0.0, PublicKeyToken=1234567812345678".
                //
                // If the extension DLL is not in the GAC, you should refer to it by
                // file path, eg. "c:/MyProject/bin/MyPipelineExtension.dll".
            };
            // MSBuild objects used to dynamically build content.
            Project buildProject;
            ProjectRootElement projectRootElement;
            BuildParameters buildParameters;
            List<ProjectItem> projectItems = new List<ProjectItem>();
            //ErrorLogger errorLogger;
            // Temporary directories used by the content build.
            string buildDirectory;
            string processDirectory;
            string baseDirectory;
            // Generate unique directory names if there is more than one ContentBuilder.
            static int directorySalt;
            // Have we been disposed?
            bool isDisposed;
            #endregion
            #region Properties
            /// Gets the output directory, which will contain the generated .xnb files.
            public string OutputDirectory
            {
                get { return Path.Combine(buildDirectory, "bin/Content"); }
            }
            #endregion
            #region Initialization
            /// Creates a new content builder.
            public ContentBuilder()
            {
                CreateTempDirectory();
                CreateBuildProject();
            }
            /// Finalizes the content builder.
            ~ContentBuilder()
            {
                Dispose(false);
            }
            /// Disposes the content builder when it is no longer required.
            public void Dispose()
            {
                Dispose(true);
                GC.SuppressFinalize(this);
            }
            /// Implements the standard .NET IDisposable pattern.
            protected virtual void Dispose(bool disposing)
            {
                if (!isDisposed)
                {
                    isDisposed = true;
                    DeleteTempDirectory();
                }
            }
            #endregion
            #region MSBuild
            /// Creates a temporary MSBuild content project in memory.
            void CreateBuildProject()
            {
                string projectPath = Path.Combine(buildDirectory, "content.contentproj");
                string outputPath = Path.Combine(buildDirectory, "bin");
                // Create the build project.
                projectRootElement = ProjectRootElement.Create(projectPath);
                // Include the standard targets file that defines how to build XNA Framework content.
                projectRootElement.AddImport("$(MSBuildExtensionsPath)\\Microsoft\\XNA Game Studio\\" +
                                             "v4.0\\Microsoft.Xna.GameStudio.ContentPipeline.targets");
                buildProject = new Project(projectRootElement);
                buildProject.SetProperty("XnaPlatform", "Windows");
                buildProject.SetProperty("XnaProfile", "Reach");
                buildProject.SetProperty("XnaFrameworkVersion", "v4.0");
                buildProject.SetProperty("Configuration", "Release");
                buildProject.SetProperty("OutputPath", outputPath);
                // Register any custom importers or processors.
                foreach (string pipelineAssembly in pipelineAssemblies)
                {
                    buildProject.AddItem("Reference", pipelineAssembly);
                }
                // Hook up our custom error logger.
                //errorLogger = new ErrorLogger();
                buildParameters = new BuildParameters(ProjectCollection.GlobalProjectCollection);
                //buildParameters.Loggers = new ILogger[] { errorLogger };
            }
        
            /// Adds a new content file to the MSBuild project. The importer and
            /// processor are optional: if you leave the importer null, it will
            /// be autodetected based on the file extension, and if you leave the
            /// processor null, data will be passed through without any processing.
            public void Add(string filename, string name, string importer, string processor)
            {
                ProjectItem item = buildProject.AddItem("Compile", filename)[0];
                item.SetMetadataValue("Link", Path.GetFileName(filename));
                item.SetMetadataValue("Name", name);
                if (!string.IsNullOrEmpty(importer))
                    item.SetMetadataValue("Importer", importer);
                if (!string.IsNullOrEmpty(processor))
                    item.SetMetadataValue("Processor", processor);
                projectItems.Add(item);
            }
            /// Removes all content files from the MSBuild project.
            public void Clear()
            {
                buildProject.RemoveItems(projectItems);
                projectItems.Clear();
            }
            /// Builds all the content files which have been added to the project,
            /// dynamically creating .xnb files in the OutputDirectory.
            /// Returns an error message if the build fails.
            public string Build()
            {
                // Create and submit a new asynchronous build request.
                BuildManager.DefaultBuildManager.BeginBuild(buildParameters);
                BuildRequestData request = new BuildRequestData(buildProject.CreateProjectInstance(), new string[0]);
                BuildSubmission submission = BuildManager.DefaultBuildManager.PendBuildRequest(request);
                submission.ExecuteAsync(null, null);
                // Wait for the build to finish.
                submission.WaitHandle.WaitOne();
                BuildManager.DefaultBuildManager.EndBuild();
                // If the build failed, return an error string.
                if (submission.BuildResult.OverallResult == BuildResultCode.Failure)
                {
                    //return string.Join("\n", errorLogger.Errors.ToArray());
                }
                return null;
            }
            #endregion
            #region Temp Directories
            /// Creates a temporary directory in which to build content.
            void CreateTempDirectory()
            {
                // Start with a standard base name:
                //
                //  %temp%\WinFormsContentLoading.ContentBuilder
                baseDirectory = Path.Combine(Path.GetTempPath(), GetType().FullName);
                // Include our process ID, in case there is more than
                // one copy of the program running at the same time:
                //
                //  %temp%\WinFormsContentLoading.ContentBuilder\<ProcessId>
                int processId = Process.GetCurrentProcess().Id;
                processDirectory = Path.Combine(baseDirectory, processId.ToString());
                // Include a salt value, in case the program
                // creates more than one ContentBuilder instance:
                //
                //  %temp%\WinFormsContentLoading.ContentBuilder\<ProcessId>\<Salt>
                directorySalt++;
                buildDirectory = Path.Combine(processDirectory, directorySalt.ToString());
                // Create our temporary directory.
                Directory.CreateDirectory(buildDirectory);
                PurgeStaleTempDirectories();
            }
            /// <summary>
            /// Deletes our temporary directory when we are finished with it.
            /// </summary>
            void DeleteTempDirectory()
            {
                Directory.Delete(buildDirectory, true);
                // If there are no other instances of ContentBuilder still using their
                // own temp directories, we can delete the process directory as well.
                if (Directory.GetDirectories(processDirectory).Length == 0)
                {
                    Directory.Delete(processDirectory);
                    // If there are no other copies of the program still using their
                    // own temp directories, we can delete the base directory as well.
                    if (Directory.GetDirectories(baseDirectory).Length == 0)
                    {
                        Directory.Delete(baseDirectory);
                    }
                }
            }
            /// <summary>
            /// Ideally, we want to delete our temp directory when we are finished using
            /// it. The DeleteTempDirectory method (called by whichever happens first out
            /// of Dispose or our finalizer) does exactly that. Trouble is, sometimes
            /// these cleanup methods may never execute. For instance if the program
            /// crashes, or is halted using the debugger, we never get a chance to do
            /// our deleting. The next time we start up, this method checks for any temp
            /// directories that were left over by previous runs which failed to shut
            /// down cleanly. This makes sure these orphaned directories will not just
            /// be left lying around forever.
            /// </summary>
            void PurgeStaleTempDirectories()
            {
                // Check all subdirectories of our base location.
                foreach (string directory in Directory.GetDirectories(baseDirectory))
                {
                    // The subdirectory name is the ID of the process which created it.
                    int processId;
                    if (int.TryParse(Path.GetFileName(directory), out processId))
                    {
                        try
                        {
                            // Is the creator process still running?
                            Process.GetProcessById(processId);
                        }
                        catch (ArgumentException)
                        {
                            // If the process is gone, we can delete its temp directory.
                            Directory.Delete(directory, true);
                        }
                    }
                }
            }
            #endregion
        }
    }
