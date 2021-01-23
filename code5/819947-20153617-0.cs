            var list = new List<string>();
            using (StreamReader reader = File.OpenText(filePath))
            {
                while(!reader.EndOfStream)
                {
                    list.Add(reader.ReadLine());
                }
            }
