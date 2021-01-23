    protected void ButtonScan_Click(...)
    {
        ButtonScan.IsEnabled = false;
        string folderName = "Root";
        Thread t = new Thead(ScanFolder);
        t.Start(folderName);
    }
    private void ScanFolder(object argument)
    {
        string folderName = (string)argument;
        int filesCount = // do scanning
        SetControlPropertyThreadSafe(myLabel, "Text", filesCount.ToString());
        ButtonScan.IsEnabled = true;
    }
    
    private delegate void SetControlPropertyThreadSafeDelegate(Control control, string propertyName, object propertyValue);
    
    public static void SetControlPropertyThreadSafe(Control control, string propertyName, object propertyValue)
    {
      if (control.InvokeRequired)
      {
        control.Invoke(new SetControlPropertyThreadSafeDelegate(SetControlPropertyThreadSafe), new object[] { control, propertyName, propertyValue });
      }
      else
      {
        control.GetType().InvokeMember(propertyName, BindingFlags.SetProperty, null, control, new object[] { propertyValue });
      }
    }
