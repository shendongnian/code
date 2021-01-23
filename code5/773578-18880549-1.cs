    string FunctionThatReturnsId()
    {
        using(var context = new YourContext())
        {
            return (from t in context.YourTable
                          where t.Conditions
                          select t.Id).FirstOrDefault();
        }
    }
    
    ...
    
    txtId.Text = FunctionThatReturnsId();
