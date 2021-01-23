    private static void ReadTextFile()
    {
        var x = File.ReadAllText(@"c:\Users\rufusl\Documents\temp.txt");
        var lastDateTime = DateTime.MinValue;
        // Open the text file
        using (var reader = new StreamReader(@"c:\Users\rufusl\Documents\temp.txt"))
        {
            while (!reader.EndOfStream)
            {
                DateTime currentDateTime;
                // Read each line and trim the extra spaces and 'Ok' from 
                // the end so we can parse the text into a DateTime object
                if (DateTime.TryParse(reader.ReadLine().TrimEnd('O', 'k', ' '), 
                    out currentDateTime))
                {
                    // If we get here, we successfully parsed the date time and set it 
                    // to 'currentDateTime'. Now we see if the lastDateTime has been set. 
                    // If it has, we do the comparison
                    if (!lastDateTime.Equals(DateTime.MinValue))
                    {
                        // See if the difference between the last date
                        // and the current date is more than 5 minutes
                        if (currentDateTime.Subtract(lastDateTime).TotalMinutes > 5)
                        {
                            // Write the values out to the console window
                            Console.WriteLine(lastDateTime);
                            Console.WriteLine(currentDateTime);
                        }
                    }
                    // Set the last date to the current date
                    lastDateTime = currentDateTime;
                }
            }
        }
    }
