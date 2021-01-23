    private void WriteData(double value)
    {
        using (var file = new System.IO.StreamWriter(@"C:\file.txt", true))
        {
        	file.WriteLine(string.Format("{0} {1}", value, DateTime.Now));
        }
    }
