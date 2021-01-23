        const string locationOfTextFiles = "C:\\Users\\Itsme\\Documents\\Visual Studio 2010\\Projects\\tsa\\tsa\\";
            var names = new string[]{ "nameOne", "nameTwo", "nameThree"};
    
            foreach(string name in names)
            {
                 using (StreamReader sr = new StreamReader(locationOfTextFiles + name + ".txt"))
                    {
                        String line = sr.ReadToEnd();
                    }
            }
