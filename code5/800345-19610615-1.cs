    Dictionary<string, string> Files = new Dictionary<string, string>();
    
    using (StreamReader sr = new StreamReader("filename.txt"))
    {
       string total = "";
       string line;
       while ((line = sr.ReadLine()) != null)
       {
          total += line;
       }
       Files.Add("filename.txt", line);
    }
