            double total = 0;
            total = TryConvert(TextBox1.Text) * 0.10;
            total = total + (TryConvert(TextBox2.Text) * 20);
            total = total + (TryConvert(TextBox2.Text) * 30);
            Lbl.Text = total.ToString();
        public int TryConvert(string s)
        {
            int i = 0;
            int.TryParse(s, out i);
            return i;
        }
