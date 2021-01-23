    class InputBox
    {
        protected virtual bool ValidateKey(char key)
        {
            // Allow anything
            return true;
        }
        
        public string Show(string i_Prompt)
        {
            using (InputBoxForm form = new InputBoxForm(i_Prompt))
            {
                form.isKeyValid = this.ValidateKey;
                if (form.ShowDialog() == DialogResult.OK)
                {
                    return form.Input;
                }
            }
            return string.Empty;
        } 
    }
    class DigitInputBox : InputBox
    {
        protected override bool ValidateKey(char key)
        {
            return key >= '0' && key <= '9';
        }
    }
