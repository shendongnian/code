        DataTable viewedData = dt_PaymentsReceived_Colletions;
        if(hideIncome.Checked) {
            viewedData.Columns.Remove("Income");
            viewedData.AcceptChanges();
        }
        DataGridView1.DataSource = viewedData;
