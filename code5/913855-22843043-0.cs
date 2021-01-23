    Outlook.Application oApp;
    try { 
        oApp = (Outlook.Application)Marshal.GetActiveObject("Outlook.Application"); 
    }
    catch () {
        oApp = new Outlook.Application();
    }
    // use oApp to send the stuff, it will either be the existing instance or a new instance
