        private void btnSave_Click(object sender, EventArgs e)
        {
           if(dataIsChanged == true)
           { 
    int price = Convert.ToInt32(txtPrice.Text);
    
            Classes.Prices prices = new Classes.Prices(comboBox1.SelectedValue.ToString(),
                Convert.ToInt32(txtPrice.Text), 
                Convert.ToInt32(txtCarbohydrate.Text), 
                Convert.ToInt32(txtProtein.Text),
                Convert.ToInt32(txtFat.Text),
                Convert.ToInt32(txtHumidity.Text), 
                Convert.ToInt32(txtminerals.Text));
            try { 
                prices.updateMaterialPrice();
                //this.comboBox1.Refresh();
                this.txtPrice.Refresh();
                int price2 = Convert.ToInt32(txtPrice.Text);
               if (price2 != price)
               {
                   MessageBox.Show("new price saved!");
               }
    
            }
                catch(Exception ex)
            {
                throw ex;
            }
                foreach (Control ctrl in this.panel1.Controls)
                {
                    if (ctrl is TextBox)
                    {
                        TextBox textbx = ctrl as TextBox;
    
                        if (textbx.ReadOnly == false)
                        {
                            textbx.ReadOnly = true;
                            textbx.BackColor = Color.LightBlue;
                        }
                    }
                }        
    
           }
        }
