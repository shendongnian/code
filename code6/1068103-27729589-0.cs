    while (Reader.Read())
    {
        var Name = UppercaseWords(Reader.GetString(0));
        kelasSelect.Rows.Add(Name);
    }
    Reader.Close();
    classSelect.CellMouseUp += FormCaller;
