     private void comboBox1_Validating(object sender, CancelEventArgs e)
            {
                var cbx = sender as ComboBox;
                if (!Enum.IsDefined(typeof(comboboxVals), cbx.Text))
                {
                    MessageBox.Show(cbx.Text + " not in the list");
                    e.Cancel=true;
                }
                else
                {
                    // Implement your logic here
                }
    
            }
