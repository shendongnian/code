    protected override void UpdateEditText()
    {
                base.ParseEditText();
                if (!string.IsNullOrEmpty(this.Text))
                {
                    decimal value;
                    decimal.TryParse(this.Text.Replace(Units,"").Trim(),out value);
                    this.Value = value;
                }
                this.Text = this.Value + " " + Units;
    }
