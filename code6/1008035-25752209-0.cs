    void Main()
    {
        var chromeProcess = new ChromeProcess();
        Console.WriteLine(chromeProcess.AnyInstancesRunning());
        Console.WriteLine(chromeProcess.NumberOfInstancesRunning());
        chromeProcess.ChromeInstanceIds().Dump("Chrome Instance Ids");
        
        chromeProcess.KillChromeInstance(2816);
        
        //open and close a few chrome windows
        chromeProcess.RefreshInstances();
        Console.WriteLine(chromeProcess.AnyInstancesRunning());
        Console.WriteLine(chromeProcess.NumberOfInstancesRunning());
        chromeProcess.ChromeInstanceIds().Dump("Chrome Instance Ids");
    }
    
    // Define other methods and classes here
    public class ChromeProcess
    {
        private const string ImageName = "chrome";
        private IEnumerable<Process> _Instances;
        
        public ChromeProcess()
        {
            _Instances = Process.GetProcessesByName(ImageName);
        }
        
        public bool AnyInstancesRunning()
        {
            return _Instances.Any();
        }
        
        public int NumberOfInstancesRunning()
        {
            return _Instances.Count();
        }
        
        public IEnumerable<int> ChromeInstanceIds()
        {
            return _Instances.Select(i => i.Id).ToArray();
        }
        
        public void KillChromeInstance(int id)
        {
            var process = Process.GetProcessById(id);
            if(process.ProcessName != ImageName)
            {
                throw new Exception("Not a chrome instance.");
            }
            process.Kill();
        }
        
        public void RefreshInstances()
        {
            _Instances = Process.GetProcessesByName(ImageName);
        }
    }
