    private delegate void ShowErrMsgMethod(string text);
    public static void ErrMsg(String strMsg, Exception ex = null)
    {
        ...
        if (ex == null)
            Form.ActiveForm.Invoke(new ShowErrMsgMethod(text => MessageBox.Show(Form.ActiveForm, text, "MyApp", MessageBoxButtons.OK, MessageBoxIcon.Warning)), strMsg);
        ...
    }
