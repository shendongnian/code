    protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
        {
           if !isPostback)
    {
            string cn = "Data Source=.;Initial Catalog=DBRE ;Integrated Security=True";
            SqlConnection scon = new SqlConnection(cn);
    
            SqlCommand scmd = new SqlCommand("Select * from Employees where FullName = '" + DropDownList1.SelectedItem.Value + "'", scon);
    
            SqlDataReader sdr;
    
            try
            {
    
               scon.Open();
    
               sdr = scmd.ExecuteReader();
               txtName.Text = sdr["FirstName"].ToString();
               txtSurname.Text = sdr["LastName"].ToString();
               txtDepartment.Text=sdr["Dept"].ToString();
               txtCostCentre.Text=sdr["CostCentre"].ToString();
    
    
            }
    
            catch (Exception ex)
            {
    
    
    
            }
    
            finally
            {
    
                scon.Close();
    
            }
    }
    }
