    public static string Show(string i_Prompt, Func<string, InputBoxForm> generator) 
    {
        string input = string.Empty;
        using (InputBoxForm form = generator(i_Prompt))
        {
            form.isKeyValid = s_Instance.keyValidationLogic;
            if (form.ShowDialog() == DialogResult.OK)
            {
                input = form.Input;
            }
        }
        return input;
    }
