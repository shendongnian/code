     private void txtboxOne_TextChanged(object sender, EventArgs e)
        {
            if (txtboxOne.Text == "z")
            {
                MessageBox.Show("The Goose Eat the Beans");
            }
    
            if (txtboxTwo.Text == "x")
            {
                lblgrpTwoSecond.Visible = true;
            }
        }
