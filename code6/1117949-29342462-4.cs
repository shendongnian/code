    private void btnCompute_Click(object sender, EventArgs e)
            { 
                double x = 0;
                if (sender.tag == "SameBehaviorComboBox")
                {
                    if (sender.SelectedItem.ToString() == "First")
                    { 
                        x = 3.5; 
                    }
                    else if (sender.SelectedItem.ToString() == "Second")
                    { 
                        x = 4; 
                    }
                }
                txtResult.Text = (x * double.Parse(txtAmount.Text)).ToString(); 
        }
