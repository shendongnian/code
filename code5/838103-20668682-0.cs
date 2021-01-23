    try
    {
        List<int> x = new List<int>();
        using (TextReader reader = File.OpenText("Numbers.txt"))
        {
            string text;
            while ((text = reader.ReadLine()) != null)
            {
                string[] bits = text.Split(' ');
                foreach (string bit in bits)
                {
                    // If you're parsing a huge file and it happens to have a
                    // decent bit of bad data, TryParse is much faster
                    int tmp;
                    if(int.TryParse(bit, out tmp))
                        x.Add(tmp);
                    else
                    {
                        // Handle bad data
                    }
                }
            }
        }
    }
    catch (Exception ex)
    {
        // Log/handle bad text file or IO
    }
