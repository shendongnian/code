    int[] dateColInfo = new int[] {1, (int)XlColumnDataType.xlDMYFormat};
    object[] fieldInfo = new object[] {dateColInfo};
    eit_books.OpenText(path, Type.Missing, 1, XlTextParsingType.xlDelimited, XlTextQualifier.xlTextQualifierDoubleQuote, false, true, false, false, false, false, Type.Missing, fieldInfo, Type.Missing, Type.Missing, Type.Missing, Type.Missing, false);
    eit_book = eit_books.get_Item(name);
    Range rng = eit_book.Worksheets.get_Item(1).range("A1");
    Console.WriteLine("{0} ISO Date: {1}", rng.Value, ((DateTime)rng.Value).ToString("yyyyMMdd"));
