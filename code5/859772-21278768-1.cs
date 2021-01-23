    int value;	
    DataTable dt = new DataTable();  
    dt = (DataTable)(dataGridViewX4.DataSource);   
    dt.DefaultView.RowFilter = string.Format("T_P = {0}",int.TryParse(Txt_T_P_Se.Text, out value));   
    dataGridViewX4.DataSource = dt;
