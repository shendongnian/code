       private void btnOK_Click(object sender, EventArgs e)
       {
          if ( Information.IsNumeric(startingbudget) )
          {
             MessageBox.Show("This is a number.");
          }
       }
