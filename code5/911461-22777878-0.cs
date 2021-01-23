    float f = 0.075f * 37 + 5.75f;
    Console.WriteLine(DoubleConverter.ToExactString(f));
    f = 5.75f;
    Console.WriteLine(DoubleConverter.ToExactString(f));
    f = f + 0.075f * 37;
    Console.WriteLine(DoubleConverter.ToExactString(f));
