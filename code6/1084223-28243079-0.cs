    Double val;
    try {
        val = Convert.ToDouble(str);
    } catch (FormatException fe) {
        Console.Error.WriteLine("Got {0} when processing '{1}'", fe.Message, str);
    }
