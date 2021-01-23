    ArrayList lines = new ArrayList();
    using (StreamReader rs = new StreamReader(@"C:\Users\vimal\Desktop\test.txt"))
    {
         string line = null;
         while ((line = rs.ReadLine()) != null)
         {
            lines.Add(line);
         }
    }
