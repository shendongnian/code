    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.IO;
    using System.Diagnostics;
    using System.Windows.Forms;
    namespace spiderBuilderNS {
      class Program {
        private static StreamWriter m_writeText;
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main(string[] args) {
          string solnName = null; // "spider_e_www_iis.sln";
          var properties = Properties.Settings.Default;
          string dataDir = properties.lastFolder;
          string solnDir = properties.localDir;
          if ((args != null) && (0 < args.Length)) {
            solnName = args[0];
            if (1 < args.Length) {
              dataDir = args[1];
              if (2 < args.Length) {
                solnDir = args[2];
              }
            }
          }
          string message = 
            "This will create a Visual Studio Solution.\r\n\r\n" +
            "If you need to save the old file first, do so now.\r\n\r\n" +
            "Are you ready to begin?";
          if (MessageBox.Show(message, "Create Solution " + solnName, MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.Yes) {
            using (var dlg = new FolderBrowserDialog()) {
              dlg.SelectedPath = dataDir;
              dlg.Description = string.Format("Specify Physical Location of Files:\r\n{0}", dataDir);
              if (dlg.ShowDialog() == DialogResult.OK) {
                dataDir = dlg.SelectedPath;
              } else {
                dataDir = null;
              }
            }
          }
          if (!String.IsNullOrEmpty(dataDir)) {
            using (var dlg = new FolderBrowserDialog()) {
              dlg.SelectedPath = solnDir;
              dlg.Description = string.Format("Specify Folder to Create Solution in:\r\n{0}", solnDir);
              if (dlg.ShowDialog() == DialogResult.OK) {
                bool buildSlnName = (args != null) && !String.IsNullOrEmpty(args[0]);
                if (buildSlnName) {
                  if (MessageBox.Show(String.Format("Call Solution '{0}'?", args[0]),
                    "Solution Name",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) == DialogResult.Yes) {
                      buildSlnName = false;
                      solnName = args[0];
                  }
                }
                if (buildSlnName) {
                  solnDir = dlg.SelectedPath;
                  var dir = new DirectoryInfo(solnDir);
                  solnName = String.Format("{0}_{1}.sln", dir.Parent.Name, dir.Name);
                }
                if (solnName.IndexOf(".sln") == -1) {
                  solnName += ".sln";
                }
              } else {
                solnDir = null;
              }
            }
          }
          if (!String.IsNullOrEmpty(dataDir)) {
            properties.lastFolder = dataDir;
          }
          if (!String.IsNullOrEmpty(solnDir)) {
            properties.localDir = solnDir;
          }
          properties.Save();
          if (!String.IsNullOrEmpty(solnDir)) {
            var logfilePath = Path.Combine(solnDir, "logfile.txt");
            if (File.Exists(logfilePath)) {
              File.Delete(logfilePath);
            }
            var logfile = new FileInfo(logfilePath);
            using (m_writeText = logfile.AppendText()) {
              var item = new SolutionBuilder(solnDir, dataDir);
              var startTime = DateTime.Now;
              Program.WriteLine("Solution {0} started at {1:g}", item.Name, startTime);
              item.Generate(solnName);
              Program.WriteLine("Solution {0} created ({1})\r\n", item.Name, DateTime.Now - startTime);
              item.Start();
              if (item.ErrorsExist) {
                var sb = new StringBuilder("The following errors were encountered:\r\n");
                foreach (var error in item.ErrorArray) {
                  sb.AppendLine("  " + error);
                }
                MessageBox.Show(sb.ToString(), "Handled Errors (skipped)");
              }
              m_writeText.Flush();
              m_writeText.Close();
            }
            Console.WriteLine("Done.\r\nPress any key to close.");
            Console.ReadKey();
          }
        }
        public static void WriteLine(string text, params object[] args) {
          string created = string.Format(text, args);
          m_writeText.WriteLine(created);
        }
      }
      public class SolutionBuilder {
        #region ' CONSTANTS '
        private const string SOLUTION_HEAD = "\r\nMicrosoft Visual Studio Solution File, Format Version 11.00\r\n# Visual Studio 2010\r\n";
        private const string FMT_PLATFORMS =
          "    {0}.Debug|x86.ActiveCfg = Debug|x86\r\n" +
          "    {0}.Debug|x86.Build.0 = Debug|x86\r\n" +
          "    {0}.Release|x86.ActiveCfg = Release|x86\r\n" +
          "    {0}.Release|x86.Build.0 = Release|x86";
        private const string FMT_GLOB_SEC = 
          "Global\r\n" +
	        "  GlobalSection(SolutionConfigurationPlatforms) = preSolution\r\n" +
          "    Debug|x86 = Debug|x86\r\n" +
		      "    Release|x86 = Release|x86\r\n" +
	        "  EndGlobalSection\r\n" +
	        "  GlobalSection(ProjectConfigurationPlatforms) = postSolution\r\n" +
          "{0}" +
	        "  EndGlobalSection\r\n" +
	        "  GlobalSection(SolutionProperties) = preSolution\r\n" +
		      "    HideSolutionNode = FALSE\r\n" +
	        "  EndGlobalSection\r\n" +
          "EndGlobal";
        #endregion
        private string m_solnName;
        private List<string> m_errors;
        private DirectoryInfo m_solnDir, m_dataDir;
        public SolutionBuilder(string solnDir, string dataDir) {
          m_errors = new List<string>();
          m_solnDir = new DirectoryInfo(solnDir);
          m_dataDir = new DirectoryInfo(dataDir);
        }
        public string Name { get { return m_solnName; } }
        public string[] ErrorArray {
          get { return m_errors.ToArray(); }
        }
        public bool ErrorsExist {
          get { return (0 < m_errors.Count); }
        }
        public void Generate(string solnName) {
          m_solnName = solnName;
          if (m_solnDir.Exists) {
            var body = new StringBuilder(SOLUTION_HEAD);
            var fullSolutionName = Path.Combine(m_solnDir.FullName, Name);
            if (File.Exists(fullSolutionName)) {
              Program.WriteLine("Creating backup of Solution {0}...", fullSolutionName);
              var refBackup = fullSolutionName.Replace('.', '_') + ".old";
              if (File.Exists(refBackup)) {
                File.Delete(refBackup);
              }
              File.Move(fullSolutionName, refBackup);
              File.Delete(fullSolutionName);
            }
            var projects = new List<Project>();
            foreach (var sub in m_dataDir.GetDirectories()) {
              Program.WriteLine(String.Empty);
              var projDir = Path.Combine(m_solnDir.FullName, sub.Name);
              var item = new Project(projDir, sub.FullName);
              item.Generate(sub.Name);
              if (item.ErrorsExist) {
                m_errors.AddRange(item.ErrorArray);
              }
              projects.Add(item);
            }
            Program.WriteLine(String.Empty);
            var globalSection = new StringBuilder();
            foreach (var item in projects) {
              var projLine = item.SolutionEntry;
              if (!String.IsNullOrEmpty(projLine)) {
                body.AppendLine(projLine);
                globalSection.AppendLine(string.Format(FMT_PLATFORMS, item.Guid));
              }
            }
            body.AppendLine(string.Format(FMT_GLOB_SEC, globalSection.ToString()));
            var file = new FileInfo(Path.Combine(m_solnDir.FullName, solnName));
            using (var sw = file.AppendText()) {
              Program.WriteLine("Saving Solution {0}...", Name);
              sw.Write(body.ToString());
              sw.Flush();
              sw.Close();
            }
          }
        }
        public void Start() {
          var path = Path.Combine(m_solnDir.FullName, m_solnName);
          Program.WriteLine("Launching Solution {0}...", Name);
          Process.Start(path);
        }
      }
      public class Project : IComparable<Project>, IEquatable<Project> {
        #region ' CONSTANTS '
        private const string FMT_FOLDER_INCLUDE =
          "    <Folder Include=\"{0}\" />";
        private const string FMT_CONTENT_INCLUDE =
          "    <Content Include=\"{0}\" >\r\n" +
          "      <Link>{1}</Link>\r\n" +
          "    </Content>";
        private const string FMT_COMPILE_INCLUDE =
          "    <Compile Include=\"{0}\" />\r\n";
        private const string FMT_COMPILE_INCLUDE_2 =
          "    <Compile Include=\"{0}\" >\r\n" +
          "      <DependentUpon>{1}</DependentUpon>\r\n" +
          "    </Compile>";
        private const string FMT_PROJ_HEAD =
          "<?xml version=\"1.0\" encoding=\"utf-8\"?>\r\n" +
          "<Project ToolsVersion=\"4.0\" DefaultTargets=\"Build\" xmlns=\"http://schemas.microsoft.com/developer/msbuild/2003\">\r\n" +
          "  <PropertyGroup>\r\n" +
          "    <Configuration Condition=\" '$(Configuration)' == '' \">Debug</Configuration>\r\n" +
          "    <Platform Condition=\" '$(Platform)' == '' \">AnyCPU</Platform>\r\n" +
          "    <ProductVersion>1.0.0.0</ProductVersion>\r\n" +
          "    <SchemaVersion>2.0</SchemaVersion>\r\n" +
          "    <ProjectGuid>{0}</ProjectGuid>\r\n" +
          "    <ProjectTypeGuids>{1};{2}</ProjectTypeGuids>\r\n" +
          "    <OutputType>Library</OutputType>\r\n" +
          "    <AppDesignerFolder>Properties</AppDesignerFolder>\r\n" +
          "    <RootNamespace>{3}_NS</RootNamespace>\r\n" +
          "    <AssemblyName>{3}_ASS</AssemblyName>\r\n" +
          "    <TargetFrameworkVersion>v4.0</TargetFrameworkVersion>\r\n" +
          "    <UseIISExpress>false</UseIISExpress>\r\n" +
          "    <TargetFrameworkProfile />\r\n" +
          "  </PropertyGroup>\r\n" +
          "  <PropertyGroup Condition=\" '$(Configuration)|$(Platform)' == 'Debug|AnyCPU' \">\r\n" +
          "    <DebugSymbols>true</DebugSymbols>\r\n" +
          "    <DebugType>full</DebugType>\r\n" +
          "    <Optimize>false</Optimize>\r\n" +
          "    <OutputPath>bin\\Debug\\</OutputPath>\r\n" +
          "    <DefineConstants>TRACE;DEBUG</DefineConstants>\r\n" +
          "    <ErrorReport>prompt</ErrorReport>\r\n" +
          "    <WarningLevel>4</WarningLevel>\r\n" +
          "    <AllowUnsafeBlocks>true</AllowUnsafeBlocks>\r\n" +
          "  </PropertyGroup>\r\n" +
          "  <PropertyGroup Condition=\" '$(Configuration)|$(Platform)' == 'Release|AnyCPU' \">\r\n" +
          "    <DebugType>pdbonly</DebugType>\r\n" +
          "    <Optimize>true</Optimize>\r\n" +
          "    <OutputPath>bin\\Release\\</OutputPath>\r\n" +
          "    <DefineConstants>TRACE</DefineConstants>\r\n" +
          "    <ErrorReport>prompt</ErrorReport>\r\n" +
          "    <WarningLevel>4</WarningLevel>\r\n" +
          "    <AllowUnsafeBlocks>true</AllowUnsafeBlocks>\r\n" +
          "  </PropertyGroup>\r\n" +
          "  <PropertyGroup Condition=\" '$(Configuration)|$(Platform)' == 'Debug|x86' \">\r\n" +
          "    <DebugSymbols>true</DebugSymbols>\r\n" +
          "    <OutputPath>bin\\Debug\\</OutputPath>\r\n" +
          "    <DefineConstants>TRACE;DEBUG</DefineConstants>\r\n" +
          "    <AllowUnsafeBlocks>true</AllowUnsafeBlocks>\r\n" +
          "    <DebugType>full</DebugType>\r\n" +
          "    <PlatformTarget>x86</PlatformTarget>\r\n" +
          "    <ErrorReport>prompt</ErrorReport>\r\n" +
          "    <UseVSHostingProcess>true</UseVSHostingProcess>\r\n" +
          "  </PropertyGroup>\r\n" +
          "  <PropertyGroup Condition=\" '$(Configuration)|$(Platform)' == 'Release|x86' \">\r\n" +
          "    <OutputPath>bin\\Release\\</OutputPath>\r\n" +
          "    <DefineConstants>TRACE</DefineConstants>\r\n" +
          "    <AllowUnsafeBlocks>false</AllowUnsafeBlocks>\r\n" +
          "    <Optimize>true</Optimize>\r\n" +
          "    <DebugType>full</DebugType>\r\n" +
          "    <PlatformTarget>x86</PlatformTarget>\r\n" +
          "    <ErrorReport>prompt</ErrorReport>\r\n" +
          "    <DebugSymbols>true</DebugSymbols>\r\n" +
          "  </PropertyGroup>\r\n" +
          "  <PropertyGroup Condition=\" '$(Configuration)|$(Platform)' == 'Debug|x64' \">\r\n" +
          "    <DebugSymbols>true</DebugSymbols>\r\n" +
          "    <OutputPath>bin\\Debug\\</OutputPath>\r\n" +
          "    <DefineConstants>TRACE;DEBUG</DefineConstants>\r\n" +
          "    <AllowUnsafeBlocks>true</AllowUnsafeBlocks>\r\n" +
          "    <DebugType>full</DebugType>\r\n" +
          "    <PlatformTarget>x64</PlatformTarget>\r\n" +
          "    <ErrorReport>prompt</ErrorReport>\r\n" +
          "  </PropertyGroup>\r\n" +
          "  <PropertyGroup Condition=\" '$(Configuration)|$(Platform)' == 'Release|x64' \">\r\n" +
          "    <OutputPath>bin\\Release\\</OutputPath>\r\n" +
          "    <DefineConstants>TRACE</DefineConstants>\r\n" +
          "    <AllowUnsafeBlocks>true</AllowUnsafeBlocks>\r\n" +
          "    <Optimize>true</Optimize>\r\n" +
          "    <DebugType>pdbonly</DebugType>\r\n" +
          "    <PlatformTarget>x64</PlatformTarget>\r\n" +
          "    <ErrorReport>prompt</ErrorReport>\r\n" +
          "  </PropertyGroup>\r\n" +
          "  <ItemGroup>\r\n" +
          "    <Reference Include=\"System\" />\r\n" +
          "    <Reference Include=\"System.Configuration\" />\r\n" +
          "    <Reference Include=\"System.Core\" />\r\n" +
          "    <Reference Include=\"System.Data\" />\r\n" +
          "    <Reference Include=\"System.Data.DataSetExtensions\" />\r\n" +
          "    <Reference Include=\"System.Drawing\" />\r\n" +
          "    <Reference Include=\"System.EnterpriseServices\" />\r\n" +
          "    <Reference Include=\"System.Web\" />\r\n" +
          "    <Reference Include=\"System.Web.Extensions\" />\r\n" +
          "    <Reference Include=\"System.Web.Mobile\" />\r\n" +
          "    <Reference Include=\"System.Web.Services\" />\r\n" +
          "    <Reference Include=\"System.Xml\" />\r\n" +
          "    <Reference Include=\"System.Xml.Linq\" />\r\n" +
          "  </ItemGroup>";
        private const string FMT_PHP_HEAD =
          "<?xml version=\"1.0\" encoding=\"utf-8\"?>\r\n" +
          "<Project ToolsVersion=\"4.0\" DefaultTargets=\"Build\" xmlns=\"http://schemas.microsoft.com/developer/msbuild/2003\">\r\n" +
          "  <PropertyGroup>\r\n" +
          "    <Configuration Condition=\" '$(Configuration)' == '' \">Debug</Configuration>\r\n" +
          "    <Name>PHPWebProject2</Name>\r\n" +
          "    <ProjectGuid>{0}</ProjectGuid>\r\n" +
          "    <OutputType>Library</OutputType>\r\n" +
          "    <RootNamespace>PHPWebProject2</RootNamespace>\r\n" +
          "    <!-- important to be opened by PHP Tools, when also Phalanger Tools are installed -->\r\n" +
          "    <ProjectTypeGuids>{1}</ProjectTypeGuids>\r\n" +
          "    <AssemblyName>{2}</AssemblyName>\r\n" +
          "  </PropertyGroup>\r\n" +
          "  <PropertyGroup Condition=\" '$(Configuration)' == 'Debug' \">\r\n" +
          "    <IncludeDebugInformation>true</IncludeDebugInformation>\r\n" +
          "  </PropertyGroup>\r\n" +
          "  <PropertyGroup Condition=\" '$(Configuration)' == 'Release' \">\r\n" +
          "    <IncludeDebugInformation>false</IncludeDebugInformation>\r\n" +
          "  </PropertyGroup>";
        private const string ITEM_GRP_START = "  <ItemGroup>";
        private const string ITEM_GRP_STOP = "  </ItemGroup>";
        private const string PROJ_FOOT =
          "  <Import Project=\"$(MSBuildBinPath)\\Microsoft.CSharp.targets\" />\r\n" +
          "  <Import Project=\"$(MSBuildExtensionsPath32)\\Microsoft\\VisualStudio\\v10.0\\WebApplications\\Microsoft.WebApplication.targets\" />\r\n" +
          "  <!-- To modify your build process, add your task inside one of the targets below and uncomment it. \r\n" +
          "      Other similar extension points exist, see Microsoft.Common.targets.\r\n" +
          "    <Target Name=\"BeforeBuild\"></Target>\r\n" +
          "    <Target Name=\"AfterBuild\"></Target>\r\n" +
          "  -->\r\n</Project>";
        private const string PHP_FOOT = "</Project>";
        private const string PHPTOOLS_GUID = "{A0786B88-2ADB-4C21-ABE8-AA2D79766269}";
        #endregion
        private static string FORBIDDEN;
        private static string[] CODEFILES, LC_EXCLUDES, WEBFILES;
        private int m_trimLeft;
        private string m_guid, m_projName, m_projDir, m_dataDir;
        private List<string> m_compiles, m_contents, m_errors, m_folders;
        private VsProjectType m_projType, m_fileType;
        public enum CodeTypes { CPP = 0, CS = 1, VB = 2 }
        public enum WebTypes { ASP, ASPX, HTML }
        static Project() {
          CODEFILES = new string[] { ".cpp", ".cs", ".vb" };
          LC_EXCLUDES = new string[] { ".svn", "desktop.ini", "thumbs.db" };
          WEBFILES = new string[] { ".asp", ".aspx", ".html" };
          FORBIDDEN = "~`!@#$%^&*()+|\\\"<>?/";
        }
        public Project(string projDir, string dataDir) {
          m_projType = VsProjectType.Unknown;
          m_fileType = VsProjectType.Unknown;
          m_compiles = new List<string>();
          m_contents = new List<string>();
          m_errors = new List<string>();
          m_folders = new List<string>();
          m_projDir = projDir;
          m_dataDir = dataDir;
          m_trimLeft = dataDir.Length + 1;
          m_guid = "{" + System.Guid.NewGuid().ToString().ToUpper() + "}";
          Program.WriteLine("Project {0} started.", Name);
        }
        public string Guid { get { return m_guid; } }
        public string[] ErrorArray {
          get { return m_errors.ToArray(); }
        }
        public bool ErrorsExist {
          get { return (0 < m_errors.Count); }
        }
        public void Generate(string projName) {
          m_projName = projName;
          Program.WriteLine("Generating Project {0}...", Name);
          if (!Directory.Exists(m_projDir)) {
            Directory.CreateDirectory(m_projDir);
          }
          Map(new DirectoryInfo(m_dataDir));
          if ((m_projType != VsProjectType.Unknown) && (m_fileType != VsProjectType.Unknown)) {
            var projFullName = Path.Combine(m_projDir, Name) + GuidAssist.ProjectExtension(m_fileType);
            Program.WriteLine("Project File: {0}", projFullName);
            if (File.Exists(projFullName)) {
              var refBackup = Path.Combine(m_projDir, string.Format("{0}.old", Name.Replace('.', '_')));
              try {
                if (File.Exists(refBackup)) {
                  File.Delete(refBackup);
                }
                File.Move(projFullName, refBackup);
              } catch (Exception err) {
                m_errors.Add(string.Format("Delete {0} Error: {1}", refBackup, err.Message));
              }
            }
            var list = new List<string>();
            if (m_projType != VsProjectType.PHP) {
              list.Add(string.Format(FMT_PROJ_HEAD, Guid, GuidAssist.ProjectGuid(m_projType), GuidAssist.ProjectGuid(m_fileType), projName)); // Non-PHP
            } else {
              list.Add(string.Format(FMT_PHP_HEAD, Guid, PHPTOOLS_GUID, projName));
            }
            if (0 < m_folders.Count) {
              m_folders.Sort();
              list.Add(ITEM_GRP_START);
              foreach (var link in m_folders) {
                list.Add(string.Format(FMT_FOLDER_INCLUDE, link));
              }
              list.Add(ITEM_GRP_STOP);
            }
            if (0 < m_contents.Count) {
              m_contents.Sort();
              m_contents.Sort();
              list.Add(ITEM_GRP_START);
              foreach (var link in m_contents) {
                list.Add(string.Format(FMT_CONTENT_INCLUDE, link, link));
              }
              list.Add(ITEM_GRP_STOP);
            }
            if (0 < m_compiles.Count) {
              m_compiles.Sort();
              list.Add(ITEM_GRP_START);
              m_compiles.Sort();
              foreach (var link in m_compiles) {
                try {
                  var value = m_compiles.First(item => (-1 < link.IndexOf(item)));
                  if (!String.IsNullOrEmpty(value)) {
                    list.Add(string.Format(FMT_COMPILE_INCLUDE_2, link, value));
                  } else {
                    list.Add(string.Format(FMT_COMPILE_INCLUDE, link));
                  }
                } catch (Exception) {
                  list.Add(string.Format(FMT_COMPILE_INCLUDE, link));
                }
              }
              list.Add(ITEM_GRP_STOP);
            }
            if (m_projType != VsProjectType.PHP) {
              list.Add(PROJ_FOOT);
            } else {
              list.Add(PHP_FOOT);
            }
            File.WriteAllLines(projFullName, list.ToArray());
          } else {
            Program.WriteLine("Project {0} was SKIPPED! (Proj={1}; Files={2})", Name, m_projType, m_fileType);
          }
        }
        private void Map(DirectoryInfo dir) {
          Program.WriteLine("  mapping {0}...", dir.FullName);
          var netFullName = dir.FullName;
          bool isRoot = (netFullName == m_dataDir);
          var relativeDir = !isRoot ? netFullName.Substring(m_trimLeft) : null;
          var subs = dir.GetDirectories();
          if (!isRoot) {
            var physicalDir = Path.Combine(m_projDir, relativeDir);
            if (!Directory.Exists(physicalDir)) {
              Directory.CreateDirectory(physicalDir);
            }
            m_folders.Add(relativeDir);
          }
          for (int i = 0; i < subs.Length; i++) {
            DirectoryInfo sub = null;
            try {
              sub = subs[i];
              if (!LC_EXCLUDES.Contains(sub.Name.ToLower()) && !Offensive(sub.Name)) {
                Map(sub);
              }
            } catch (Exception err) {
              m_errors.Add(string.Format("{0}: {1}", err.GetType(), err.Message));
            }
          }
          if (!isRoot) {
            var files = dir.GetFiles();
            for (int i = 0; i < files.Length; i++) {
              FileInfo file = null;
              try {
                file = files[i];
                var name = file.Name.ToLower();
                if (!LC_EXCLUDES.Contains(name) && !Offensive(name)) {
                  var ext = file.Extension.ToLower();
                  if ((m_fileType == VsProjectType.Unknown) || (m_projType == VsProjectType.Unknown)) {
                    if (WEBFILES.Contains(ext) && (m_projType == VsProjectType.Unknown)) {
                      m_projType = VsProjectType.WebSite;
                    }
                    if (ext == CODEFILES[(int)CodeTypes.CPP]) {
                      m_fileType = VsProjectType.WindowsCpp;
                    } else if (ext == CODEFILES[(int)CodeTypes.CS]) {
                      m_fileType = VsProjectType.WindowsCs;
                    } else if (ext == ".php") {
                      m_fileType = VsProjectType.PHP;
                      m_projType = VsProjectType.PHP;
                    } else if (ext == CODEFILES[(int)CodeTypes.VB]) {
                      m_fileType = VsProjectType.WindowsVb;
                    }
                  }
                  if (((m_fileType == VsProjectType.WindowsCs) || (m_fileType == VsProjectType.WindowsVb)) &&
                    ((m_projType == VsProjectType.WebSite) || (m_projType == VsProjectType.Unknown))) {
                      m_projType = VsProjectType.WebApplication;
                  }
                  var link = Path.Combine(relativeDir, file.Name);
                  if (CODEFILES.Contains(ext)) {
                    m_compiles.Add(link);
                  } else {
                    m_contents.Add(link);
                  }
                }
              } catch (Exception err) {
                m_errors.Add(string.Format("{0}: {1}", err.GetType(), err.Message));
              }
            }
          }
        }
        public string Name { get { return m_projName; } }
        private bool Offensive(string name) {
          if (!String.IsNullOrEmpty(name)) {
            foreach (char c in name) {
              if (-1 < FORBIDDEN.IndexOf(c)) {
                return true;
              }
            }
            return false;
          }
          return true;
        }
        public string SolutionEntry {
          get {
            if ((m_projType != VsProjectType.Unknown) && (m_fileType != VsProjectType.Unknown)) {
              return string.Format("Project(\"{0}\") = \"{1}\", \"{1}\\{1}{2}\", \"{3}\"\r\nEndProject",
                GuidAssist.ProjectGuid(m_projType), Name, GuidAssist.ProjectExtension(m_fileType), Guid);
            }
            return null;
          }
        }
        public int CompareTo(Project other) {
          return Guid.CompareTo(other.Guid);
        }
        public bool Equals(Project other) {
          return Guid.Equals(other.Guid);
        }
      }
      public enum VsProjectType {
        WindowsCs, WindowsVb, WindowsCpp,
        WebApplication, WebSite,
        DistributedSystem, WCF, WPF,
        VisualDbTools, Db, DbOther,
        Test,
        LegacySmartDeviceCs, LegacySmartDeviceVb,
        SmartDeviceCs, SmartDeviceVb,
        WorkflowCs, WorkflowVb,
        DeploymentMergeMod, DeploymentCab, DeploymentSetup, DeploymentSmartDeviceCab,
        VsToolsForApps, VsToolsForOffice,
        SharePointWorkflow,
        XnaWindows, XnaZbox, ZnaZune,
        SharePointVb, SharePointCs,
        Silverlight,
        AspNetMvc1, AspNetMvc2, AspNetMvc3, AspNetMvc4,
        Extensibility,
        PHP,
        Unknown=-1
      }
      public class GuidAssist {
        private static List<string> m_guidList;
        static GuidAssist() {
          m_guidList = new List<string>();
          m_guidList.AddRange(new string[] {
            "{FAE04EC0-301F-11D3-BF4B-00C04F79EFBC}", "{F184B08F-C81C-45F6-A57F-5ABD9991F28F}", "{8BC9CEB8-8B4A-11D0-8D11-00A0C91BC942}",
            "{349C5851-65DF-11DA-9384-00065B846F21}", "{E24C65DC-7377-472B-9ABA-BC803B73C61A}",
            "{F135691A-BF7E-435D-8960-F99683D2D49C}", "{3D9AD99F-2412-4246-B90B-4EAA41C64699}", "{60DC8134-EBA5-43B8-BCC9-BB4BC16C2548}",
            "{C252FEB5-A946-4202-B1D4-9916A0590387}", "{A9ACE9BB-CECE-4E62-9AA4-C7E7C5BD2124}", "{4F174C21-8C12-11D0-8340-0000F80270F8}",
            "{3AC096D0-A1C2-E12C-1390-A8335801FDAB}",
            "{20D4826A-C6FA-45DB-90F4-C717570B9F32}", "{CB4CE8C6-1BDB-4DC7-A4D3-65A1999772F8}",
            "{4D628B5B-2FBC-4AA6-8C16-197242AEB884}", "{68B1623D-7FB9-47D8-8664-7ECEA3297D4F}",
            "{14822709-B5A1-4724-98CA-57A101D1B079}", "{D59BE175-2ED0-4C54-BE3D-CDAA9F3214C8}",
            "{06A35CCD-C46D-44D5-987B-CF40FF872267}", "{3EA9E505-35AC-4774-B492-AD1749C4943A}", "{978C614F-708E-4E1A-B201-565925725DBA}", "{AB322303-2255-48EF-A496-5904EB18DA55}",
            "{A860303F-1F3F-4691-B57E-529FC101A107}", "{BAA0C2D2-18E2-41B9-852F-F413020CAA33}",
            "{F8810EC1-6754-47FC-A15F-DFABD2E3FA90}",
            "{6D335F3A-9D43-41b4-9D22-F6F17C4BE596}", "{2DF5C3F4-5A5F-47a9-8E94-23B4456F55E2}", "{D399B71A-8929-442a-A9AC-8BEC78BB2433}",
            "{EC05E597-79D4-47f3-ADA0-324C4F7C7484}", "{593B0543-81F6-4436-BA1E-4747859CAAE2}",
            "{A1591282-1198-4647-A2B1-27E5FF5F6F3B}",
            "{603C0E0B-DB56-11DC-BE95-000D561079B0}", "{F85E285D-A4E0-4152-9332-AB1D724D3325}", "{E53F8FEA-EAE0-44A6-8774-FFD645390401}", "{E3E379DF-F4C6-4180-9B81-6769533ABE47}",
            "{82B43B9B-A64C-4715-B499-D71E9CA2BD60}",
            "{FAE04EC0-301F-11D3-BF4B-00C04F79EFBC}",
            "-1"
          });
        }
        public static string ProjectGuid(VsProjectType projectType) {
          return m_guidList[(int)projectType];
        }
        public static string ProjectExtension(VsProjectType projectType) {
          switch (projectType) {
            case VsProjectType.LegacySmartDeviceCs:
            case VsProjectType.SharePointCs:
            case VsProjectType.SmartDeviceCs:
            case VsProjectType.WindowsCs:
            case VsProjectType.WorkflowCs:
              return ".csproj";
            case VsProjectType.LegacySmartDeviceVb:
            case VsProjectType.SharePointVb:
            case VsProjectType.SmartDeviceVb:
            case VsProjectType.WindowsVb:
            case VsProjectType.WorkflowVb:
              return ".vbproj";
            case VsProjectType.WindowsCpp:
              return ".cppproj";
            case VsProjectType.PHP:
              return ".phpproj";
            default:
              return ".proj";
          }
        }
      }
    }
