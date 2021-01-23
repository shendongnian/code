    public class ProcessTracker {
        public Dictionary<int, string> Processes { get; set; }
        public ProcessTracker() {
            Processes = new Dictionary<int, string>();
        }
        public void AddProcess(Process process, string name) {
            Processes.Add(process.Id, name);
        }
        //Check if what processes are still open after crash.
        public void UpdateProcesses() {
            List<Process> runningProcesses =
                Process.GetProcesses().ToList();
            Processes = Processes
                .Where(pair => runningProcesses
                    .Any(process => process.Id == pair.Key))
                .ToDictionary(pair => pair.Key, pair => pair.Value);
        }
        //Use this to see if you have to restart a process.
        public bool HasProcess(string name) {
            return Processes.Any(pair => pair.Value != name);
        }
        //Write the file on crash.
        public void ReadFile(string path) {
            if (!(new FileInfo(path).Exists))
                return;
            using (StreamReader reader = new StreamReader(path)) {
                foreach (string line in  reader.ReadToEnd()
                    .Split(new[] {"\n"}, StringSplitOptions.RemoveEmptyEntries)) {
                    string[] keyPair = line.Split(',');
                    Processes.Add(int.Parse(keyPair[0]), keyPair[1]);
                }
            }
        }
        //Read the file on startup.
        public void SaveFile(string path) {
            using (StreamWriter writer = new StreamWriter(path, false)) {
                foreach (KeyValuePair<int, string> process in Processes) {
                    writer.WriteLine("{0},{1}",
                        process.Key, process.Value);
                }
            }
        }
    }
