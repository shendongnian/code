            using (StreamReader reader = new StreamReader("C:\\Users\\lorenzov\\Desktop\\gi_pulito_neg.txt"))
            {
                string line;
                while (!reader.EndOfStream)
                {
                    line = reader.ReadLine();
                    // ... process the line
                }
            }
