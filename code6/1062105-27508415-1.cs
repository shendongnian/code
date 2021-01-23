    public static class TextBoxExtensions{
        public static void TriggerKeyPress(this TextBox textbox, KeyPressEventArgs e)
        {
            MethodInfo dynMethod = textbox.GetType().GetMethod("OnKeyPress", 
            BindingFlags.NonPublic | BindingFlags.Instance);
            dynMethod.Invoke(textbox, new object[]{ e });
        }
    }
