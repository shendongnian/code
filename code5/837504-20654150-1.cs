    if ViewState("temp") == null
    {
    DataTable dt = new DataTable();
    DataRow dr;
    dt.Columns.Add("Firstname");
    dt.Columns.Add("Lastname");
    dt.Columns.Add("PhoneNumber");
    dr = dt.NewRow();
    dr["Firstname"] = tb1.Text;
    dr["Lastname"] = tb2.Text;
    dr["PhoneNumber"] = tb3.Text;
    dt.Rows.Add(dr);
    dataGridView1.DataSource = dt; 
    ViewState("temp")=dt;
    }
    esle
    {
    DataTable dt = ViewState("temp")
    DataRow dr;
    dr =dt.Rows.Add();
    dr["Firstname"] = tb1.Text;
    dr["Lastname"] = tb2.Text;
    dr["PhoneNumber"] = tb3.Text;
    dt.Rows.Add(dr);
    dataGridView1.DataSource = dt; 
    ViewState("temp")=dt;
    }
