    using System.Text // This goes at the top of the file, with the other using statements.
    ...
    public void GetData() 
    {
        StringBuilder sb = new StringBuilder();
        foreach (var row in MyRows)
        {
            sb.Append("<tr><td>" + row.someProperty + "</td></tr>");
        }
        string myTableString = sb.ToString();
