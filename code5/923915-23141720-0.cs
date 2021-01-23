    public void editline()
        {
            string[] lines = File.ReadAllLines("link.txt");
            foreach (var line in lines)
            {
               line = line.Substring(51,171);
               line = line.Replace("%3A", ":");
              line =  line.Replace("%2F","/");
               line = line.Replace("%3F","?");
               line = line.Replace("%3D" , "=");
               line = line.Replace("%26","&");
            }
            File.WriteAllLines("output.txt",lines);
        }
