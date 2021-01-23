              foreach (var line in File.ReadAllLines(path))
                {
                  if(!String.IsNullOrWhiteSpace(line))
                  {
                    // HERE IS THE ERROR
                    rows.Add(line.Split(new[] { ' ' },StringSplitOptions.RemoveEmptyEntries).Select(double.Parse).ToArray());  
                  }                
                }
