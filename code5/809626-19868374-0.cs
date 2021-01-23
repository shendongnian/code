    private void btnSubmit_Click(object sender, EventArgs e)
            {
                string strColor;
                string strMake;
                decimal decPrice;
        
                GetColor(ref strColor);
                GetMake(ref strMake);
                GetPrice(ref decPrice);
                DisplayResult(strColor, strMake, decPrice);
        }
    private void GetColor(ref string color){
                    color = lstColor.SelectedItem.ToString();
         }
       private void GetMake(ref string make){
                    make = lstMake.SelectedItem.ToString();
                }
       private void GetPrice(ref decimal price){
                    if (decimal.TryParse(txtMaxPrice.Text, out price)){
                    }
                    else{
                        MessageBox.Show("Enter a valid number");
                    }
                }
       private void DisplayResult(string color, string make, decimal price){
                    lblMessage.Text = "Color of " + color + " Make of: " + make + " " +price.ToString("c");
                }
