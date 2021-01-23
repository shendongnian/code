    private void readFileButton_Click(object sender, EventArgs e)
    {
        // If you use the stream this way it will be disposed automatically.
        using (var sr = new StreamReader(sourceFileString))
        {
            while (!sr.EndOfStream)
            {
                string readString = sr.ReadLine();
                var flds = readString.Split(',');
                string patID = flds[0];
                int months = int.Parse(flds[1]);
                //I prefer parameters more than fields to communicate between methods.
                Random(months);
            }
            
        }
    }
    Random randomGenerator = new Random();
    private void Random(int months)
    {
        randomInteger = randomGenerator.Next(1, months) + 1;
    }
