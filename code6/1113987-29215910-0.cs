    Using table As New DataTable()
        table.Columns.Add("Id", GetType(Integer))
        table.Columns.Add("Price", GetType(Decimal))
        table.Rows.Add(1231I, 100D)
        table.Rows.Add(1232I, 150D)
        table.Rows.Add(1235I, 150D)
        'Add a new computed column:                    expr
        table.Columns.Add("Flag", GetType(Integer), "[id] % 10")
        For Each row As DataRow In table.Rows
            Debug.WriteLine("{0}    {1}    {2}", row.ItemArray)
        Next
    End Using
