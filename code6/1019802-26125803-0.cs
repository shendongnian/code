    class Folder 
    {
        ...
        public void AddFile(string name)
        {
            Children.Add(new File(this, name));
        }
    }
