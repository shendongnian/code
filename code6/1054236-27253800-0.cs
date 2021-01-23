    try
    {
        Class2 class2 = container.GetExportedValue<Class2>();
    }
    catch (CompositionException ex)
    {
        foreach (var cause in ex.RootCauses)
        {
            //Check if current cause is the Exception we're looking for
            var myError = cause as MyException;
            //If it's not, check the inner exception (chances are it'll be here)
            if (myError == null)
                myError = cause.InnerException as MyException;
    
            if (myError != null)
            {
                //do what you want
            }
        }
    }
