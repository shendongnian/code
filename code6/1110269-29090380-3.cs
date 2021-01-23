    ListBox1.DisplayMember = ListBox2.DisplayMember = "FullRowDisplay";
    foreach (DataRow tempRow_Variable in myDataTable.Rows)
        {
            tempRow = tempRow_Variable;
            ListBox2.Items.Add(new UserDetails(tempRow["ID"], tempRow["Firstname"], tempRow["Middlename"], tempRow["Lastname"]));
        }
