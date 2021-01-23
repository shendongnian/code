    public override void AddRaw(dynamic anything)
    {
        // pseudo code
        DataTable dt = new DataTable();
        foreach(row r in anything)
        {
            dt.AddRow(r);
        }
        this.Add(dt);
    }
