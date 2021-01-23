    for (int i = 0; i < 100; i++)
    {
        string istr = i.ToString();
        System.IO.File.WriteAllText(istr, istr + ".txt", System.Text.Encoding.ASCII);
    }
