    OK as mentioned by Sudhakar, Try this
    
        protected void btnSearchGroup_Click(object sender, EventArgs e)
                {
                    string selectedValues = string.Empty;
        
                    foreach (ListItem item in cblGroup.Items)
                    {
                        if (item.Selected)
                            selectedValues += "'" + item.Value + "',";
                    }
        
                    if (selectedValues != string.Empty)
                        selectedValues = selectedValues.Remove(selectedValues.Length - 1);//To remove the last comma;
        
        
                    SqlConnection con = new SqlConnection(strcon);
                    SqlCommand cmd = new SqlCommand("select * from AppInvent_Test where Designation in (" + selectedValues + ")", con);
                    SqlDataAdapter Adpt = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    Adpt.Fill(dt);
                    GridView1.DataSource = dt;
                    GridView1.DataBind();
        
                }
