    using System.Collections.Generic;
    using System.Linq;
    using Microsoft.Windows.Kits.Hardware.ObjectModel;
    using Microsoft.Windows.Kits.Hardware.ObjectModel.DBConnection;
    using System.IO;
    using System.Threading;
    using Microsoft.Management.Infrastructure;
    using Microsoft.Management.Infrastructure.Options;
    using System.Security;
    using System.Net.Mail;
    using System.Text;
    using System.Net.NetworkInformation;
    using System.Net;
    using System.Collections.ObjectModel;
    namespace HLKAutomation
    {
        class Program
        {
            public static string sExePath = 
    Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location);
        public static string sLogFile = "HLK_Test_Log.txt"; //complete console logged in this text file
        
        //connct to controller
        public static ProjectManager ConnectToController(string controllerName)
        {
            ProjectManager manager = null;
            try
            {
                manager = new DatabaseProjectManager(controllerName);
                if (manager == null)
                {
                    Console.WriteLine("Error! Couldnt connect to Controller {0}", controllerName);
                    Log("Error! Couldnt connect to Controller " + controllerName);
                }
                else
                {
                    Log("Connected to controller " + controllerName);
                }
            }
            catch(Exception ex)
            {
                Console.WriteLine("Exception:- {0}", ex.ToString());
                Environment.Exit(1);
            }
            return manager;
        }
        //create project
        public static Project CreateProject(ProjectManager manager, string projectName)
        {
            Project project = null;
            try
            {
                if(manager == null)
                {
                    Log("Project manager value is null");
                    Console.WriteLine("Project manager value is null");
                    Console.ReadLine();
                    return project;
                }
                //delete project by the name projectname if exist
                foreach (string sProj in manager.GetProjectNames())
                {
                    if (sProj == projectName)
                    {
                        Log(String.Format("Error! Project {0} already found!", sProj));
                        Log("deleting this project");
                        manager.DeleteProject(sProj);
                        Log("Deleted " + sProj);
                    }
                }
                project = manager.CreateProject(projectName);   //creating project
                Log("Created project: " +  projectName);
            }
            catch(Exception e)
            {
                Console.WriteLine("Exception {0}", e.ToString());
            }
            return project;
        }
        //create pool
        public static MachinePool CreatePool(ProjectManager manager, string TestPoolName)
        {
            MachinePool testPool = null;
            try
            {
                MachinePool rootPool = manager.GetRootMachinePool();
                //create test pool
                Log("Creating test pool");
                testPool = manager.GetRootMachinePool().GetChildPools().Where(x => x.Name == TestPoolName).FirstOrDefault();
                if (testPool == null)
                {
                    Log("Pool:- " + TestPoolName + " not found, creating");
                    testPool = manager.GetRootMachinePool().CreateChildPool(TestPoolName);
                    Log("Created " + TestPoolName);
                }
                else
                    Log("Test pool " + testPool.Name + " already found");
            }
            catch(Exception e)
            {
                Console.WriteLine("Exception {0}", e.ToString());
            }
            return testPool;
        }
        //add target machine to test pool
        public static Machine LookForMachine(ProjectManager manager, string TargetName, MachinePool testpool)
        {
            Machine TargetMachine = null;
            try
            {
                bool bFoundInDefault = false;
                bool bFoundInTest = false;
                
                MachinePool RootPool = manager.GetRootMachinePool();
                //check if machine is in default pool or test pool
                foreach (Machine m in testpool.GetMachines())
                {
                    if (m.Name == TargetName)
                    {
                        bFoundInTest = true;
                        TargetMachine = m;
                    }
                }
                foreach(Machine m in RootPool.DefaultPool.GetMachines())
                {
                    if (m.Name == TargetName)
                    {
                        bFoundInDefault = true;
                        TargetMachine = m;
                    }
                }
                if (bFoundInTest == true)
                {
                    Log("Machine already in test pool!");
                    return TargetMachine;
                }
                Log("Checking for machine " + TargetName + " in default pool" );
                if (bFoundInDefault == true)
                {
                    Log("Machine " + TargetName + " is in default pool");
                    Log("Moving to test pool");
                    RootPool.DefaultPool.MoveMachineTo(TargetMachine, testpool);
                    Log("Moved machine " + TargetMachine.Name +" from default to test pool");
                    return TargetMachine;
                }                     
                if(bFoundInDefault == false)
                {
                    Log("Warning!!! Machine " + TargetName + " not found in default pool too");
                    Console.ReadLine();
                }
            }
            catch(Exception e)
            {
                Console.WriteLine("Exception:-{0}", e.ToString());
            }
            return TargetMachine;
        }
        //make systems readt
        public static void PrepareTargetMachine(Machine machine)
        {
            try
            {
                if(machine == null)
                {
                    Log("Machine is N/A");
                    return;
                }
                if(machine.Status == MachineStatus.Ready || machine.Status == MachineStatus.Running)
                {
                    Log(String.Format("Machine {0} is {1}", machine.Name.ToString(), machine.Status.ToString()));
                    return;
                }
                if(machine.Status == MachineStatus.NotReady)
                {
                    Log("Making system ready");
                    machine.SetMachineStatus(MachineStatus.Ready, -1);
                    if (machine.Status == MachineStatus.Ready)
                    {
                        Log("Machine is ready");
                        return;
                    }
                }
                if(machine.Status == MachineStatus.Initializing)
                {
                    Log("Warning Machine is still initializing!!!");
                    Console.ReadLine();
                }
            }
            catch(Exception e)
            {
                Console.WriteLine("Exception {0}", e.ToString());
            }
        }
        //list tests
        public static IList<Test> GetTestsSystemLevel(Machine TargetName, MachinePool testPool, Project project)
        {
            IList<Test> Test_List = new List<Test> { };
            try
            {                
                OSPlatform platform = testPool.GetMachines().First().OSPlatform;
                ProductInstance pi = project.CreateProductInstance(project.Name, testPool, platform);      
                TargetData data = pi.FindTargetFromSystem(TargetName);                
                if (data == null)
                {
                    Log("Error! No target data found in system " + TargetName.Name);
                    Console.ReadLine();
                    return Test_List;
                }
                pi.CreateTarget(data);
                IList<Test> tests = project.GetTests();
                if (tests.Count == 0)
                {
                    Log("Warning! Test list count is 0");
                    Console.ReadLine();
                    return Test_List;
                }
                Test_List = tests;
            }
            catch (Exception e)
            {
                Console.WriteLine("Exception :- {0}", e.ToString());
            }
            return Test_List;
        }
        //list tests
        public static IList<Test> GetTestsDeviceLevel(Machine TargetName, MachinePool testPool, Project project)
        {
            IList<Test> Test_List = new List<Test> { };
            try
            {
                OSPlatform platform = testPool.GetMachines().First().OSPlatform;
                ProductInstance pi = project.CreateProductInstance(project.Name, testPool, platform);
                //Device Level
                ReadOnlyCollection<TargetData> devices = testPool.GetMachines().First().GetTestTargets();
                TargetData device_tpm = null;
                //Find TPM device
                foreach (TargetData device in devices)
                {
                    if (device.Name.Contains("Trusted Platform Module 2.0"))
                    {
                        Console.WriteLine(device.Name);
                        device_tpm = device;
                    }
                }
                pi.CreateTarget(device_tpm);
                IList<Test> tests_tpm = project.GetTests();
                if (tests_tpm.Count == 0)
                {
                    Log("Warning! Device Level Test list count is 0");
                    Console.ReadLine();
                    return tests_tpm;
                }
                Test_List = tests_tpm;
            }
            catch (Exception e)
            {
                Console.WriteLine("Exception :- {0}", e.ToString());
            }
            return Test_List;
        }
        //apply filters
        public static PlaylistManager ApplyPlaylist(Project projectname, string playlistpath)
        {
            PlaylistManager pl_manager = null;
            try
            {
                pl_manager = new PlaylistManager(projectname);
                if (pl_manager == null)
                {
                    Log(String.Format("Cannot make playlist manager for the project:- {0}", projectname.Name.ToString()));
                }
                if(pl_manager.IsPlaylistLoaded() == true)
                {
                    Log("Playlist loaded.. unloading ");
                    pl_manager.UnloadPlaylist();
                    if (pl_manager.IsPlaylistLoaded() == false)
                    { 
                        Log("Unloaded successfully");
                    }
                }
                else
                {
                    if (File.Exists(playlistpath))
                    {
                        pl_manager.LoadPlaylist(playlistpath);
                        if (pl_manager.IsPlaylistLoaded() == false)
                        {
                            Log("Error in applying playlist:- " + playlistpath);
                        }
                        else
                        { 
                            Log("Loaded playlist:- " + playlistpath);
                        }
                    }
                    else
                    {
                        Log(String.Format("ERROR!Playlist file {0} not found!", playlistpath));
                        return pl_manager;
                    }
                }
            }
            catch(Exception e)
            {
                Console.WriteLine("Exception:-{0}", e.ToString());
            }
            return pl_manager;
        }
        //load pl
        public static IList<Test> LoadPlaylist(Project project, string playlistpath)
        {
            IList<Test> test_list = null;
            try
            {                
                PlaylistManager pl_manager = new PlaylistManager(project);
                pl_manager.LoadPlaylist(playlistpath);
                if (pl_manager.IsPlaylistLoaded() == true)
                {
                    Log(String.Format("Playlist loaded:- {0}", playlistpath));
                }
                else
                {
                    Log("Error loading playlist");
                }
                test_list = project.GetTests();
                Log(String.Format("{0} tests found", test_list.Count.ToString()));
            }
            catch(Exception e)
            {
                Console.WriteLine("Exception:-{0}", e.ToString());
            }
            return test_list;
        }
               
        //run tests
        public static List<string> RunTests(Project project, IList<Test> test_list, int iID)
        {
            List<int> result = new List<int> { };
            List<string> Results = new List<string> { };
            try
            {                              
                IList<TestResult> res_list = null;
                double time = 0;
                List<Test> test_tpm=new List<Test> { };
                
                //system level
                if (iID == 1)
                {
                    foreach (Test t in test_list)
                    {
                        if (t.Name.ToLower().Contains("tpm 2.0") && !t.Name.ToLower().Contains("interface 1.3 test"))
                        {
                            test_tpm.Add(t);
                        }
                    }
                }
                //device level
                if (iID == 2)
                {
                    foreach (Test t in test_list)
                    {
                        if (t.Name.ToLower().Contains("tpm"))
                        {
                            test_tpm.Add(t);
                        }
                    }
                }
                
                //get total time
                foreach (Test t in test_tpm)
                {
                    time += t.EstimatedRuntime.TotalSeconds;
                }
                Log(string.Format("Total test time:- {0}", time.ToString()));
                                
                foreach (Test t in test_tpm)
                {          
                    res_list = t.QueueTest();
                    Log(string.Format("Queued test:-{0}", t.Name.ToString()));
                }
                
                while (project.Info.Status == ProjectStatus.Running)
                {
                    if(project.Info.Status == ProjectStatus.NotRunning)
                    {
                        break;
                    }
                    Log(string.Format("Running count:-{0}", project.Info.RunningCount.ToString()));    
                    Log(string.Format("Waiting for {0} secs", time.ToString()));
                    Thread.Sleep(Convert.ToInt32(time) * 1000);   //millisec  
                    Log(string.Format("{0} secs elapsed", time.ToString()));
                    Log(string.Format("Running count:-{0}", project.Info.RunningCount.ToString()));
                }
                //check results
                Log(string.Format("Passed count:-{0}", project.Info.PassedCount.ToString()));
                Log(string.Format("Failed count:-{0}", project.Info.FailedCount.ToString()));
                
                foreach(Test t in test_tpm)
                {
                    Results.Add(ProcessTest(t));
                }
                //PackageWriter package = new PackageWriter(project);
                //package.Save(sPackageName);
            }
            catch (Exception e)
            {
                Console.WriteLine("Exception:- {0}", e.ToString());
            }
            return Results;
        }
        //process a test result
        public static string ProcessTest(Test test)
        {
            string sOutput = null;
            try
            {
                foreach (var result in test.GetTestResults())
                {
                    string sTestTargetDevice = string.Join("; ", from a in test.GetTestTargets()
                                                                select a.Name);
                    Log("Test: " + test.Name);
                    sOutput+=(String.Format("TestCase:-{0}\n", test.Name));
                    Log("Target: " + sTestTargetDevice);
                    sOutput+=(String.Format("Target:-{0}\n", sTestTargetDevice));
                    Log("Test Result: " + test.Status.ToString());
                    sOutput+=(String.Format("Test Result:- {0}\n",test.Status.ToString() ));
                    Log("RunTime (min): " + System.Math.Round((result.CompletionTime - result.StartTime).TotalMinutes));
                    sOutput+=(String.Format("Runtime:-{0}\n", System.Math.Round((result.CompletionTime - result.StartTime).TotalMinutes)));
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("Exception:-{0}",e.Message);
            }
            return sOutput;
        }
        //Log into log file
        public static void Log(string sMsg)
        {
            try
            {
                Console.WriteLine(sMsg);
                File.AppendAllText(Path.Combine(sExePath,sLogFile), sMsg + "\n");                
            }
            catch (Exception e)
            {
                Console.WriteLine("Exception:-{0}", e.Message);
            }
        }
        //MAIN
        static void Main(string[] args)
        {                          
            try
            {
                string controllerName = "HLK-RS3";
                string projectName = null, TargetName = null, TestPoolName = null;
                if (args.Length != 3)   //syntax
                {
                    Console.WriteLine("Invalid arguments:-\nSyntax:-\nHLKAutomation.exe TargetName projectName TestPoolName");
                    return;
                }
                TargetName = args[0];
                projectName = args[1];
                TestPoolName = args[2];
                string sExePath = Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location);
                string playlistpath = Path.Combine(sExePath, "playlist.xml");
                List<int> PassFailCount = new List<int> { };
                List<string> Results = new List<string> { };
                if (File.Exists(Path.Combine(sExePath, sLogFile)))     //delete log file if exist
                {
                    File.Delete(Path.Combine(sExePath, sLogFile));
                }
                ProjectManager manager = ConnectToController(controllerName);   //connect to controller
                Project project = CreateProject(manager, projectName);     //create project if not exist  
                MachinePool testpool = CreatePool(manager, TestPoolName);   //create test pool                
                Machine TargetMachine = LookForMachine(manager, TargetName, testpool);    //check if test machine is there in test pool or not, if in default, move to test pool                
                if (TargetMachine != null)   //if system is valid
                {
                    PrepareTargetMachine(TargetMachine);   //now make it ready  
                    IList<Test> test_list = GetTestsDeviceLevel(TargetMachine, testpool, project);  //get list of tests
                    Console.WriteLine("{0} tests found", test_list.Count.ToString());                    
                    test_list = LoadPlaylist(project, playlistpath);    //load playlist
                    Results = RunTests(project, test_list, 2);          //run filtered tests          
                    Console.ReadLine();
                }
                
                else
                {                   
                    Console.WriteLine("Error! Machine is N/A");
                    Console.ReadLine();                    
                }    
                
            }
            catch(Exception e)
            {
                Console.WriteLine("Exception in main:- {0}", e.ToString());
            }
            
        }
    }
}
