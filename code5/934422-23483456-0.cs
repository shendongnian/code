    // Add the Form as an argument at the end --------------->  ___here___
    public static void AiProccess(string pType, String[] pArgs, Form1 form)
    {
        if (pType == "event")
        {
            string pEvent = pArgs[0];
            aiEvent(pEvent, form); // pass it in
        }
    }
    public static void aiEvent(string pEvent, Form1 form){
        if (pEvent == "powerOn")
        {
            // use the "form" variable here
            form.Mind.Text = "test";
            form.Mind.AppendText("Are you my Creator?");
        }
    }
