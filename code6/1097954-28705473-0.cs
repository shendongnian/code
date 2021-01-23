c#
    Microsoft.VisualBasic.Interaction.AppActivate(ProcessId);
    Threading.Thread.Sleep(20);
To capture the active window, I used the following. Added a delay of 200, then convert the clipboard object to an image.
c#
    SendKeys.SendWait("%{PRTSC}");
    Threading.Thread.Sleep(200);
    IDataObject objData = Clipboard.GetDataObject();
