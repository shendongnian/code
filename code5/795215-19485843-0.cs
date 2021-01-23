                decimal Discount;
                if (decimal.TryParse(postDiscountCostTextBox.Text, System.Globalization.NumberStyles.Currency, null, out Discount))
                {
                    if (Discount <= 999.99m)
                    {
                        MessageBox.Show("This amount qualifies for 'A-100' frequent flier miles.",
                            "",
                            MessageBoxButtons.OK);
                    }
                }
                else
                {
                    // ... invalid value in textbox ...
                    // Dipslay a MessageBox?
                }
