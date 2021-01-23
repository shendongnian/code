    Outlook.Inspector inspector = null;
    Outlook.MailItem sourceMail = null;
    Outlook.MailItem replyMail = null;
    try
    {
        inspector =  Application.ActiveInspector();
        sourceMail = inspector.CurrentItem as MailItem;
        replyMail = sourceMail.Reply();
        // any modifications if required    
        replyMail.Send(); // just change mail to replyMail because mail variable ///is not declare 
    }
    catch (Exception ex)
    {
        System.Windows.Forms.MessageBox.Show(ex.Message,
            "An exception is occured in the code of add-in.");
    }
    finally
    {
        if (sourceMail != null) Marshal.ReleaseComObject(sourceMail);
        if (replyMail != null) Marshal.ReleaseComObject(replyMail);
        if (inspector != null) Marshal.ReleaseComObject(inspector);
    }
