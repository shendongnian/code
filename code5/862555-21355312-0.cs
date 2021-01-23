           if (txtDiscount.Text == "" || txtGrandTotal.Text == "")
            {
                MessageBox.Show("Please Enter amount in Grand Total", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                //  double percent;
                double grandTotal;
                double per;
                double txDiscount;
                //percent = Convert.ToInt32(txtPercant.Text);
                grandTotal = Convert.ToInt32(txtGrandTotal.Text);
                txDiscount = Convert.ToInt32(txtDiscount.Text);
                per= Convert.ToInt32(txtPercant.Text);
                if (per > 0)
                {
                    
                    txtDiscount.Text =((per / 100) * grandTotal).ToString();
                }
                else if (txDiscount > 0)
                {
                    per = txDiscount / grandTotal * 100;
                    //per =  Math.Round(per, 3);
                    per = Math.Truncate(per * 1000) / 1000;
                    txtPercant.Text = Convert.ToString(per);
                }
