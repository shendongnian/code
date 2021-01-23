    private void btnCheck_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < product.Length; i++)
            {
                if (cbProduct.SelectedIndex.Equals(i))
                {
                    lblRetail.Text = retailprice[i].ToString();
                }
            }
        }
