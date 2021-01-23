    class Class1
    {
        public StreamWriter file;
        public Class1(StreamWriter file)
        {
           this.file = file;
        }
        public void onChanged(object sender, FileSystemEventArgs e)
        {
            file.WriteLine("Changed: " + e.FullPath);
            file.AutoFlush = true;
        }
    }
