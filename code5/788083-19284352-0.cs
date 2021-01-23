    StringBuilder _sb = new StringBuilder();
    _sb.Append(string.Format("{0,5}|", "MM")); // serie to cancel
    _sb.Append(string.Format("{0,20}|", "45444")); // folio to cancel
    _sb.Append(string.Format("{0,30}|", "")); // account number (optional
    Console.WriteLine(">" + _sb.ToString() + "<");
    >   MM|               45444|                              |<
