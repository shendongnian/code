        private void txtDiscount_TextChanged(object sender, EventArgs e)
        {
            if (txtDiscount.Text.Equals(""))
            {
                txtDiscount.Text = "0";
                txtDiscount.Select(txtDiscount.Text.Length, 0);
            }
            if (!txtDiscount.Text.Equals("0"))
            {
                txtDiscount.Text = txtDiscount.Text.TrimStart('0');
                txtDiscount.Select(txtDiscount.Text.Length, 0);
            }
            Regex regex = new Regex(@"^\d+\.?\d{0,2}$");
            if (!regex.IsMatch(txtDiscount.Text))
            {
                txtDiscount.Text = txtDiscount.Text.Substring(0, txtDiscount.Text.Length - 1);
                txtDiscount.Select(txtDiscount.Text.Length, 0);
            }
        }
