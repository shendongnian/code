    //only number And single decimal point input فقط عدد و یک ممیز میتوان نوشت
            public void onlynumwithsinglepoint(object sender, KeyPressEventArgs e)
            {
                if (!(char.IsDigit(e.KeyChar) || e.KeyChar == (char)Keys.Back || e.KeyChar == '.'))
                { e.Handled = true; }
                TextBox txtDecimal = sender as TextBox;
                if (e.KeyChar == '.' && txtDecimal.Text.Contains("."))
                {
                    e.Handled = true;
                }
            }
