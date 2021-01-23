    char[] invalidPathChars = Path.GetInvalidPathChars();
    foreach (string newfile in lines)
        {
            if (invalidPathChars.Intersect(newfile).Any())
            {
              Console.WriteLine(newfile + " contains invalid characters for file name");
              continue;
            }
            File.Create(newfile);
        }
