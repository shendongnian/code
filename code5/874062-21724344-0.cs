    private void btnSave_Click(object sender, EventArgs e)
	{
		try
		{
			if (txtpath.Text == "")
			{
				con.Open();
				cmd = new SqlCommand("insert into CourierMaster(srno)values(" + txtsrNo.Text +")", con);
			}
			else
			{
				byte[] FileData = ReadFile(txtpath.Text);                        
				con.Open();
				cmd = new SqlCommand("insert into CourierMaster(srno, OriginalPath,FileData)values(" + txtsrNo.Text + ",@OriginalPath, @FileData)", con);
				cmd.Parameters.Add(new SqlParameter("@OriginalPath", (object)txtpath.Text));
				cmd.Parameters.Add(new SqlParameter("@FileData", (object)FileData));
			}
			int n = cmd.ExecuteNonQuery();
			if (n > 0)
			{
				MessageBox.Show("Record for "+txtsrNo.Text+" Inserted Successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
			}
			else
				MessageBox.Show("Insertion failed");
		}
		catch (SqlException ex)
		{
			MessageBox.Show(ex.Message);
		}
		finally
		{
			con.Close();
		}
	}
