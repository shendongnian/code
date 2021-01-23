    protected override void OnClick(EventArgs e)
    {
        isChecked();
        base.OnClick(e);
    }     
    public object EditingControlFormattedValue
    {
        get
        {
            if (!this.Checked)
            {
                return String.Empty;                    
            }
            else
            {
                if (this.Format == DateTimePickerFormat.Custom)
                {
                    return this.Value.ToString();
                }
                else
                {
                    return this.Value.ToShortDateString();
                }
            }
        }
        set
        {
            string newValue = value as string;
            if (!String.IsNullOrEmpty(newValue))
            {
                this.Value = DateTime.Parse(newValue);
            }
        }
    }
