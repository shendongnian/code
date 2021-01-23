    private void comboBox1_DrawItem(object sender, DrawItemEventArgs e)
            {
                Brush brush = null;
                ComboBox combo;
    
                try
                {
                    e.DrawBackground();
    
                    combo = (ComboBox)sender;
                    Product pdt = (Product)combo.Items[e.Index];
    
                    if (pdt.ProductName.Contains("*"))
                    {
                        brush = Brushes.Red;
                    }
                    else
                    {
                        brush = Brushes.Black;
                    }
    
                    e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
                    e.Graphics.DrawString(pdt.ProductName, combo.Font, brush, e.Bounds.X, e.Bounds.Y);
                }
                catch (Exception Ex)
                { 
                }
            }
