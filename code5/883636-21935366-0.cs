    var manualDateChange = false;
    
    void datepicker_valuechange(object sender, DateTimeValueChangedEventArgs e)
    {
        if(manualDateChange) return;
        //Do your validation here
    }
    void someFunctionThatChangesTheDate()
    {
        manualDateChange = true; //prevent the validation code from running
        datepicker.Value = DateTime.Now;
        manualDateChange = false; //allow it to run again
    }
