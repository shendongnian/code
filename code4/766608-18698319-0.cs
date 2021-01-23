    string messageReceiptDate = "2014-02-03T19:00:00";
    string MessageRecieptDate = messageReceiptDate.Replace("T", " ").Remove(messageReceiptDate.Length - 3);
    IFormatProvider culture = new CultureInfo("en-US");
    DateTime dt = new DateTime();
    dt = DateTime.ParseExact(MessageRecieptDate, "yyyy-MM-dd HH:mm", culture);
    Console.WriteLine(dt);
