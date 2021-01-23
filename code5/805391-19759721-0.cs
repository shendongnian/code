    public string GetCSV(DateTime startDate, DateTime endDate, string separator = ",")
    {
        var data = this.GetData(startDate, endDate);
        var csvData = this.ToCsv("\"" + separator + "\"", data);
        var result = string.Join(Environment.NewLine, csvData);
        return result;
    }
