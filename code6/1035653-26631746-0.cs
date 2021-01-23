    var dt = new DataTable();
    dt.Columns.Add("ID", typeof (long));
    dt.Columns.Add("Name", typeof (string));
    dt.Rows.Add(1, "xxx");
    dt.Rows.Add(2, "yyy");
    dt.AcceptChanges(); // now both rows are in 'Unchanged' state
    dt.Rows[1].Delete(); // second row now in 'Deleted' state
    foreach (DataRow dro in dt.Rows)
    {
        if (dro.RowState == DataRowState.Deleted)
            // accessing deleted row
            Console.WriteLine("Deleted row: ID={0}, Name={1}", dro["ID", DataRowVersion.Original], dro["Name", DataRowVersion.Original]);
        else
            // accessing row as usual
           Console.WriteLine("Row: ID={0}, Name={1}", dro["ID"], dro["Name"]);
    }
    //putting into another array changes nothing in the manner of acessing deleted row
    DataRow[] dra = new DataRow[] {dt.Rows[1]};
    Console.WriteLine("Deleted row from another array: ID={0}", dra[0]["ID", DataRowVersion.Original]);
