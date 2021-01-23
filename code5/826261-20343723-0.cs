    public interface ITreeItem
        {
            string Name { get; }
            List<ITreeItem> childs { get; }
        }
    
    
        public class Company : ITreeItem
        {
    
            public string Name
            {
                get { return name; }
            }
    
            public List<ITreeItem> childs
            {
                get { return listofProjects; }
            }
        }
    
        public class Project : ITreeItem
        {
            public string Name
            {
                get { return name; }
            }
    
            public List<ITreeItem> childs
            {
                get { return listofTask; }
            }
        }
    
        public class Task : ITreeItem
        {
            public string Name
            {
                get { return name; }
            }
        }
