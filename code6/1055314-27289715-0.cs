    protected override void OnFormClosing(FormClosingEventArgs e)
    {
       yourWordObject.Quit();
       System.Runtime.InteropServices.Marshal.FinalReleaseComObject(yourWordObject);
       base.OnFormClosing(e);
           
    }
