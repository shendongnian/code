    private void button1_Click(object sender, EventArgs e)
         {
             while (true)
             {
                int Product = multiplier1 * multiplier2;
                label2.Text = multiplier1 + "x" + multiplier2 + "=" + Product;
                string product = Product.ToString();    
    
                if (product == textBox1.Text)
                {
                    label3.Text = "Your Multipliers Are" + multiplier1 + "x" + multiplier2;
                    break;
                }
                else
                {
                    multiplier1++;
                    multiplier2++;
                }    
            }
        }
