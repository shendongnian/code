    for (int i = 0; i < 10; i++)
    {
         Console.WriteLine(
             char
             .ConvertFromUtf32(
                 int.Parse("00A"+ i, System.Globalization.NumberStyles.HexNumber)));
    }
