    static void Main(string[] args)
    {
        DataTable datatable = new DataTable();
        StreamReader streamreader = new StreamReader(@"C:\Temp\txt.txt");
        char[] delimiter = new char[] { '\t' };
        string[] columnheaders = streamreader.ReadLine().Split(delimiter);
        foreach (string columnheader in columnheaders)
        {
            datatable.Columns.Add(columnheader); // I've added the column headers here.
        }
        while (streamreader.Peek() > 0)
        {
            DataRow datarow = datatable.NewRow();
            datarow.ItemArray = streamreader.ReadLine().Split(delimiter);
            datatable.Rows.Add(datarow);
        }
        foreach (DataRow row in datatable.Rows)
        {
            Console.WriteLine("----------");
            foreach (DataColumn column in datatable.Columns)
            {
                //check what columns you need
                if (column.ColumnName == "Column2" || 
                    column.ColumnName == "Column12" ||
                    column.ColumnName == "Column45") 
                {
                    Console.Write(column.ColumnName);
                    Console.Write(" ");
                    Console.WriteLine(row[column]);
                }
            }
        }
        Console.ReadLine();
    }
