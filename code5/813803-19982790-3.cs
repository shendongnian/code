    private delegate void ShowErrMsgMethod(string text);
    public static void ErrMsg(String strMsg, Exception ex = null)
    {
        ...
        if (ex == null)
        {
            Form activeForm = Form.ActiveForm ?? Application.OpenForms.Cast<Form>().Last();
            activeForm.Invoke(new ShowErrMsgMethod(text => MessageBox.Show(activeForm, text, "MyApp", MessageBoxButtons.OK, MessageBoxIcon.Warning)), strMsg);
        }
        ...
    }
