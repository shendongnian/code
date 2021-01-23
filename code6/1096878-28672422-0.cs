    public double Power(double a)
        {
            double equals = Math.Pow(a, 3);
            return equals;
        }
    
        private void button1_Click(object sender, EventArgs e)
        {
             var a=100;
             var res= Power(a);
             textBox1.Text = res.ToString();
             MessageBox.Show(res);
        }
    }
