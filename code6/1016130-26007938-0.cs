    bool bueno = true;//spanish for good
    try
    {
        payRt = Convert.ToDouble(PayRate.Text);
        payRt = double.Parse(PayRate.Text);
        //I cant figure out what im doing wrong here..
        hrsWrked = double.Parse(HoursWorked.Text);
    }
    catch (System.FormatException fEX)
    {
        bueno = false;
        Response.Write(fEX.Message);//you could do more here 
    }
    catch (System.OverflowException ofEX)
    {
        bueno = false;
        Response.Write(ofEX.Message);//you could do more here 
    }
    catch (System.ArgumentException aEX)
    {
        bueno = false;
        Response.Write(aEX.Message);//you could do more here 
    }
    
    //I would do more about these errors but this is an example
    
    
    if(bueno)
    {
        double overtimePayRt = payRt * 1.5;
        if (Page.IsPostBack)
        {
