You can also fix the error by opting for the non-generic method overload of GetRecords, which better suits the method signature you're already using.
    private static object GetCSVRecords(string path, Type t)
    {
        using (var txtReader = new StreamReader(path))
        {
            var csv = new CsvReader(txtReader);
            return csv.GetRecords(t);
        }
    }
