    public class SuperClass 
    {
        public Arguments Args { get; set; }
        public class Stat
        {
            public int DownloadCount { get; set; }
        }
        public class File
        {
            public int Id { get; set; }
            public string Name { get; set; }
            public List<Stat> SomeStats { get; set; }
        }
        public class Arguments 
        {
            public ObservableCollection<File> Files { get; set; }
        }
    }
