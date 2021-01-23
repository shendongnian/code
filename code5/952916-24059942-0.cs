    public void Page_Load()
    {
        var myControl ((MyCustomUserControl)FindControl("MyControlName"));
        // On 'myControl' you can now access all the public properties like your textbox.
    }
