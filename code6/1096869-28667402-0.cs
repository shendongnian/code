      using (var reader = new StreamReader(file))
        {
            while (!reader.EndOfStream)
            {
                var line = reader.ReadLine();
                if (line.Contains("NormalWalkSpeed="))
                    {
                       //get its value
                    }
             }
        }
        
