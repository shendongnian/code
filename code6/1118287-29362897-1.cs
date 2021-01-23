    public void Process(DataTable dt)
    {
        foreach(DataRow row in dt.Rows)
        {
            MyArgs args = new MyArgs();
            int id = Convert.ToInt32(row["Id"]);
            args.UpdateId(id);
            processor.Process(args);
        }
    }
