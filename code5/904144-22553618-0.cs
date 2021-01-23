    public string TextBox1Value
    {
        get
        {
            return tbEndDate.Text;
        }
        set
        {
            // tbEndDate.Text = TextBox1Value; //<-- you need to use "value" keyword here
            tbEndDate.Text = value;
        }
    }
