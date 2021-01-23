        public void print_quant(object Sender, EventArgs e)
        {
            TextBox quanty;
            quanty = (TextBox)this.Controls.Find("QUANTITY" + (count), true)[0];
            //add this line
            quanty.Text = calculate_quant(this, e).ToString();
        }
        public static string result;
        
        //change this 
        //public void calculate_quant(object sender, EventArgs e)
        //to
        public string calculate_quant(object sender, EventArgs e)
        {
            TextBox sfrom;
            sfrom = (TextBox)this.Controls.Find("SFRM" + count, true)[0];
            TextBox sto;
            sto = (TextBox)this.Controls.Find("STO" + count, true)[0];
            //this isn't being used here 
            //TextBox quan;
            //quan = (TextBox)this.Controls.Find("QUANTITY" + count, true)[0];
            //if (!string.IsNullOrEmpty(sfrom.Text) && !string.IsNullOrEmpty(sto.Text))
            {
                int to = Convert.ToInt32(sto.Text);
                int from = Convert.ToInt32(sfrom.Text);
                int quantity = (to - from) + 1;
               return  quantity.ToString();
            }
        }
