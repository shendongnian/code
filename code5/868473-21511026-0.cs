    Form2 sub = new Form2();
    sub.RegisterParent(this);
    for (int x = 1; x <= 5; x++ )
    {
        string[] row;
        row = new string[] { "1","2"};
        sub.DGVFile.Rows.Add(row);
    }
    sub.ShowDialog(); // open when everything is prepared
