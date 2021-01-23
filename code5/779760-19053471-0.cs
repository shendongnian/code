    [TestMethod]
    public void stuff()
    {
        using (var ms = new MemoryStream())
        {
            using (var sw = new StreamWriter(ms))
            {
                sw.Write("x,y,z"); //"x,y,z" is usually a line of string data from a textfile
                sw.Flush();
                stream.Seek(0, SeekOrigin.Begin);
                stuff2(ms);
            }
        }
    
    }
