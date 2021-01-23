    while ((line = reader.ReadLine()) != null)
    {
        int y;
        if (int.TryParse(line, out y)) {
            if ((y % 2) == 0)
            {
                file.WriteLine(" Number " + y + " in line " + Count + " is even ");
            }
            else
            {
                file.WriteLine(" Number " + y + " in line " + Count + " is odd ");
            }
        } else {
            file.WriteLine(String.Format("Invalid formatted string in line number {0}: {1}", Count, line));
        }
        Count++;
    }
