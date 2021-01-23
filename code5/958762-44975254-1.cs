        public class Operation<T>
    {
        public string path;
        public Operation()
        {
            var path = Path.Combine(Directory.GetCurrentDirectory(), "nodes.txt");
            if (File.Exists(path) == false)
            {
                using (File.Create(path))
                {
                }
            }
            this.path = path;
        }
        public void Write(string path, List<T> nodes)
        {
            var ser = JsonConvert.SerializeObject(nodes, Formatting.Indented);
            File.WriteAllText(path, ser);
        }
        public List<T> Read(string path)
        {
            var text = File.ReadAllText(path);
            var res =  JsonConvert.DeserializeObject<List<T>>(text);
            return res;
        }
        
    }
