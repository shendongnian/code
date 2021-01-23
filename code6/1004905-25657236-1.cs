         private void btnAdd_Click(object sender, EventArgs e)
         {
            int counter = 0;
            if (dg.Rows.Count > 1)
            {
                 while (counter != dg.Rows.Count - 1)
                 {
                     if (dg.Rows[counter].Cells[0].Value.ToString() ==txtName.Text)
                     {
                          MessageBox.Show("name already exist");
                          return;
                      }
                      counter++;
                 }
            }
            if (txtName.Text == "")
            {
                 MessageBox.Show("name field should not be empty");
                 return;
            }
            else
            {
                dg.Rows.Add(txtName.Text);
            }
       }
