    using (var outfile = new StreamWriter(Filepath))
    {
        foreach (var line in Results)
        {
            StringBuilder sb = new StringBuilder();
            foreach (var field in line)
            {
                sb.Append(field + ",");
            }
            sb.Length = sb.Length -1;
            outfile.WriteLine(sb.ToString());
        }
    }
