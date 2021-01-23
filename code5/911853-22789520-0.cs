    int foo;
    if( !Int32.TryParse( something.Text, out foo ) )
    {
        lblError.Text = "You must enter a number.";
    }
    else
    {
        Response.Redirect...
    }
