    [Conditional("DEBUG")]
    static void TitleCheck(Title title)
    {
        if( title.Culture == null || title.Religion == null )
        {
            System.Diagnostics.Debugger.Break();
        }
    }
    private void MyProductionFunction(Title title)
    {
        // Do some stuff
        TitleCheck(title); //<< This function call will be omitted completely if 'debug' conditional isn't met.
        // Do more stuff
    }
