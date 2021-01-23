      try {
     double numA = Convert.ToInt32(tbx1.Text); 
    double numB = Convert.ToInt32(tbx2.Text);
     double numC = Convert.ToInt32(tbx3.Text);
        
            tblk1.Text = area(numa,numb,numc).ToString();
                }
                catch (FormatException fE)
                {
                    MessageBox.Show("Input must be in text format");
                }
                catch (Exception eX)
                {
                    MessageBox.Show("Number is negative!");
                }
        
            public double area(int numA ,int numb ,int numc )
            {
                area = (numA + numB + numC) / 2;
                return area;
            }
