    class MyTextBox : TextBox
    {
        protected override void OnKeyDown(KeyEventArgs e)
        {
            decimal value = 0;
            if (Decimal.TryParse(this.Text, out value))
            {
                if (value < 0)
                {
                    this.Background = System.Windows.Media.Color.Red;
                }
                else
                {
                    this.Background = System.Windows.Media.Color.White;
                }
            }
            base.OnKeyDown(e);
        }
    }
