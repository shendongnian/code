            const int sizeLimitInBytes = 500*1024*1024;
            using (var stream = new FileStream("data.csv", FileMode.Append))
            using (var writer = new StreamWriter(stream))
            {
                writer.WriteLine("Name, Age, Job, Address");
                foreach (var currentData in allData)
                {
                    if (stream.Position > sizeLimitInBytes)
                    {
                        break;
                    }
                    writer.WriteLine("..."); // write data seperated by commas
                }
            }
