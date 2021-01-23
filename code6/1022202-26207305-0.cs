    private void btnAdd_Click(object sender, EventArgs e)
    {
    	var cnString = global::CIMT.Properties.Settings.Default.Database2ConnectionString;
    	using (SqlConnection cn = new SqlConnection(cnString))
    	{
    		try 
    		{
    			cn.Open();
    			using (var exesql = new SqlCommand(
    					  @"INSERT INTO Students(Student_Id
    											,First_Name
    											,Last_Name
    											,Fathers_Name
    											,DOB
    											,Mobile
    											,Address
    											,Post_Code) 
    						VALUES(@Student_Id
    								,@First_Name
    								,@Last_Name
    								,@Fathers_Name
    								,@DOB
    								,@Mobile
    								,@Address
    								,@Post_Code);",
    			cn))
    			{
    				exesql.Parameters.AddWithValue("@Student_Id", this.txtId.Text);
    				exesql.Parameters.AddWithValue("@First_Name", this.txtFName.Text);
    				exesql.Parameters.AddWithValue("@Last_Name",this.txtLName.Text );
    				exesql.Parameters.AddWithValue("@Fathers_Name", this.txtFaName.Text);
    				exesql.Parameters.AddWithValue("@DOB", this.txtDOB.Text);
    				exesql.Parameters.AddWithValue("@Mobile", this.txtMob.Text);
    				exesql.Parameters.AddWithValue("@Address", this.txtAddress.Text);
    				exesql.Parameters.AddWithValue("@Post_Code", this.txtPostCode.Text);
    
    				exesql.ExecuteNonQuery();
    
    				MessageBox.Show("Add new record done !!" , "Message" , MessageBoxButtons.OK 
    				                , MessageBoxIcon.Information);
    				this.studentsTableAdapter.Fill(this.database2DataSet.Students);
    			}
    		}
    		catch (Exception ex) 
    		{
    			MessageBox.Show(ex.Message , "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
    		}
    	}
    }
