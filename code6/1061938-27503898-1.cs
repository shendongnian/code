    using (OracleDB db = new OracleDB())
    {
        if (name.Checked)
        {
            var sql = String.Format("Select [name] FROM People WHERE [name] = {0}", comboBox1.SelectedItem.ToString())
            var nameDT = db.Select(sql, "Osoby");
        }
    }
