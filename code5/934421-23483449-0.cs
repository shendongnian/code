    public static void aiEvent(string pEvent)
    {
        if (pEvent == "powerOn")
        {
            Form1 ele = new Form1();  // new instance, unrelated to the form displayed
            ele.Mind.Text = "test";
            ele.Mind.AppendText("Are you my Creator?");
        }
    }
