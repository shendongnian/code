     public static bool HasPermission=true;
     private void checkcon()
      {
         try
         {
           MSSQL.SqlConnection con = new MSSQL.SqlConnection(constr);
           con.Open();
           
           con.Close();
         }
         catch (Exception ex)
         { 
           HasPermission=false;
           MessageBox.Show("Your domain account does not have sufficient privilages to    continue with the application please contact the IS support Team.");              
           Close();
         }
    
      }
     private void Form1_FormClosing(object sender, FormClosingEventArgs e)
      { if (HasPermission)
        {
        DialogResult result = MessageBox.Show("Are you sure you want to exit the application?", "Alert", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
         if (result == DialogResult.No)
         {
            e.Cancel = true;
         }
         else
         {
         }
         }
      }
