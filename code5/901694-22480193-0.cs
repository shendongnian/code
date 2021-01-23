    int value;
    string input = myTable.Rows[i].Cells["column1"].Value.ToString();
    if(int.TryParse(input, out value))
    {
        ...
    }
