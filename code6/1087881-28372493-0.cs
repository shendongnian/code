    protected void Page_Load(Object sender, EventArgs e)
    {
        if (/* I want to kill processing)
        {
            // Method one:
            Response.End(); // Though admittedly ugly
            // Method two:
            this.Context.ApplicationInstance.CompleteRequest();
            return; // return as normal (short-circuit)
        }
    }
