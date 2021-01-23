    private void MyForm_Load(object sender, EventArgs e)
    {
         //Retrieve all textbox details from table as dataset.
         for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
         {
                    System.Windows.Forms.TextBox txtbox = new System.Windows.Forms.TextBox();
                    txtbox.Text = ds.Tables[0].Rows[i]["Content"].ToString();
                    txtbox.Left = Convert.ToInt32(ds.Tables[0].Rows[i]["Left"].ToString());
                    txtbox.Top = Convert.ToInt32(ds.Tables[0].Rows[i]["Top"].ToString());
                    panel1.Controls.Add(txtbox);
                    txtbox.Visible = true;
         }
    }
