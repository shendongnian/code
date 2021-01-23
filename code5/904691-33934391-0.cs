    DateTime date_of_submission = Convert.ToDateTime(DateTime.Now.ToString("MM/dd/yyyy"));
    DateTime _effective_date = Convert.ToDateTime(TextBox32.Text);
    
    DateTime lastPossibleEffectiveDate = _effective_date.AddDays(90);
    
    int result = DateTime.Compare(_effective_date,lastPossibleEffectiveDate);
    if (result <= 0)
        Console.WriteLine("Valid Date");
    else if (result > 0 )
        Console.WriteLine("Not Valid effective date");
             
