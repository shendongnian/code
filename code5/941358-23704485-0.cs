    public void DeserialStream(string filePath)
    {
        using (var sr = new StreamReader(filePath))
        {
            // header
            var dateLine = sr.ReadLine();
            var expirationDateLine = sr.ReadLine();
            var lotLine = sr.ReadLine();
            var serialLine = sr.ReadLine();
            // skip next two lines
            sr.ReadLine();
            sr.ReadLine()
            // csv data
            string currentline;
            while ((currentline = sr.ReadLine()) != null)
            {
                
                Console.WriteLine(currentline);
                
            }
        }
    }
