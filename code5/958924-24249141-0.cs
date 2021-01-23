    int count=0;
    foreach(Object item in emailFolder.Items)
    {
        try
        {
            Outlook.MailItem _item = (Outlook.MailItem)item;
            Console.WriteLine(_item.SenderEmailAddress + " " + _item.Subject + "\n" + _item.Body);
            ++count;
            if (count == 500)
                break;
        }
        catch(Exception ex)
        {
        }
}
