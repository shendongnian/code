    string myDate = "03-Jan-2010";
    DateTime dt = DateTime.Now;
    DateTime.TryParseExact(myDate, "dd-MMM-yyyy", null, System.Globalization.DateTimeStyles.None, out dt);
    string formattedDate = dt.ToString("dd/MM/yyyy");
    Console.Write("Formatted Date : {0}", formattedDate);
    Console.ReadKey();
