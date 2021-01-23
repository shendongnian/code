    Binding bind = (sender as Control).DataBindings[0];
    DataTable table = (bind.DataSource as DataSet).Tables[0];
    string table_column_name = bind.BindingMemberInfo.BindingMember;
    string column_name = table_column_name.Split(new char[] { '.' })[1];
    DataColumn column = table.Columns[table.Columns.IndexOf(column_name)];
    object data = table.Rows[0][column];
