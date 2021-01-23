    public void changePrice(Int32 price)
        {
            if (InvokeRequired)
            {
                this.Invoke(new Action<Int32>(changePrice), new object[] { price });
                return;
            }
            txtPrice.Text = ""+ price;          
        }
