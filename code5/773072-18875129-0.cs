    using (StreamWriter writer = new StreamWriter(File.Open(mypath, FileMode.Append)))
    {
        writer.Write(this.framenumber + " " + timestamp.ToString("F3", CultureInfo.InvariantCulture.NumberFormat));
        writer.WriteLine();
        writer.Write(String.Join(",", realPoints.Select(p => p.X).ToArray()));
        writer.WriteLine();
        writer.Write(String.Join(",", realPoints.Select(p => p.Y).ToArray()));
        writer.WriteLine();
        writer.Write(String.Join(",", realPoints.Select(p => p.Z).ToArray()));
        writer.WriteLine();
        writer.WriteLine();
        framenumber++;
    }
