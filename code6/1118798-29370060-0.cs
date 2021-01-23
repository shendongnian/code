     private void txtslider2_TextChanged(object sender, TextChangedEventArgs e)
                {                
                        string val = (txtslider2.Text != "") ? txtslider2.Text : "0";
                        SL2.Value = int.Parse(val);                
                }
