    int intID = 5;
    DataTable Dt = MyFuctions.GetData();
    Dt.PrimaryKey = new DataColumn[] { Dt.Columns["ID"] };
    DataRow Drw = Dt.Rows.Find(intID);
    if (Drw != null) Dt.Rows.Remove(Drw);
