    using Objects;
    public class XMLWorker
    {
        public Project Project { get; private set; }
        public XMLWorker(string path)
        {
            Project = new Project();
            Dictionary<string, string> data = GetData(path);
            Project.Variables["second_name"].Value = data["second_name"];
        }
        internal Dictionary<string, string> GetData(string path)
        {
            // method implementation
        }
    }
