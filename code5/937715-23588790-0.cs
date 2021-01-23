    using (MemoryStream ms = new MemoryStream)
    {
        StreamWriter sw = new StreamWriter(ms, System.Text.Encoding.UTF8)
        sw.WriteLine("This is a test.");
        sw.WriteLine("This is a second line.");
        sw.Flush();
        using (FileStream fs = new FileStream("Test.txt", FileMode.Create))
        {
            ms.CopyTo(fs);
        }
        sw.Close();
    }
