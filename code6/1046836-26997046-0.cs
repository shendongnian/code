    void MyMethod(object sender, EventArgs e)
    {
        switch(e.GetType().FullName)
        {
            case "MyNamespace.MyEventArgs":
                //seriously, don't do this.
                break;
            case "System.EventArgs":
                //this is the worst idea ever.
                break;
            default:
                break;
        }
    }
