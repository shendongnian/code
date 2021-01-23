    class EuroUpDown : NumericUpDown
    {
        protected override void UpdateEditText()
        {
            ChangingText = true;
            Regex decimalRegex = new Regex(@"(\d+([.,]\d{1,2})?)");
            Match m = decimalRegex.Match(this.Text);
            if (m.Success)
            {
                Text = m.Value;
                
            }
            ChangingText = false;
            base.UpdateEditText();
            ChangingText = true;
            
            Text = this.Value.ToString("C", CultureInfo.CurrentCulture);
        }
    }
