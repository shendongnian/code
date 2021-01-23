            // Example #3: Write only some strings in an array to a file. 
            // The using statement automatically closes the stream and calls  
            // IDisposable.Dispose on the stream object. 
            using (System.IO.StreamWriter file = new System.IO.StreamWriter(@"C:\Users\Public\TestFolder\WriteLines2.txt"))
            {
                foreach (string line in lines)
                {
                    // If the line doesn't contain the word 'Second', write the line to the file. 
                    if (!line.Contains("Second"))
                    {
                        file.WriteLine(line);
                    }
                }
            }
