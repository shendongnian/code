    protected  void Foo()
        {
            // Use DateTime.TryParse when input is valid.
            string input = "2014-02-02T04:00:00";//"2014-02-02";
            DateTime dateTime;
            if (DateTime.TryParse(input, out dateTime))
            {
                lblresult.Text = dateTime.ToString();
            }
            else {
                lblresult.Text = "invalid";
            }
    }
