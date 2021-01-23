    void backgroundWorker1_ProgressChanged(object sender, ProgressChangedEventArgs e)
    {
        var myList = e.UserState as List<List<string>>;
        if (myList != null)
        {
            // use list
            return;
        }
        int myNumber;
        if (Int32.TryParse(e.UserState.ToString(), out myNumber))
        {
            // use number
            return;
        }
        var myString = e.UserState.ToString();
        // use string
    }
