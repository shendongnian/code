       var context = new NameEntities();
        BindingSource bi = new BindingSource();
        //here, instead of putting tablename is there a way to put 
        //combox item name? I have tried combobox.Text.ToString(), 
        //but it doesn't work, shows error 
        var TableName = combobox.Text.ToString();
        bi.DataSource = obj.GetType().GetProperty(TableName).GetValue(obj, null);
        dgvLoadTable.DataSource = bi;
        dgvLoadTable.Refresh();
