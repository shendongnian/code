    public static Form MainFormInstance; // Set this in the main form constructor!
    private delegate void ShowErrMsgMethod(string text);
    public static void ErrMsg(String strMsg, Exception ex = null)
    {
        ...
        if (ex == null)
            MainFormInstance.Invoke(new ShowErrMsgMethod(text => MessageBox.Show(MainFormInstance, text, "MyApp", MessageBoxButtons.OK, MessageBoxIcon.Warning)), strMsg);
        ...
    }
