    class MyTextBox : TextBox
        {
    
            public bool IsMyTextBoxEmpty()
            {
                if (!string.IsNullOrEmpty(this.Text.Trim()))
                {
                    return true;
                }
                return false;
            }
    
            public bool IsContainsValideSpaces()
            {
               //...........Your Logic is Here
                return false;
            }
    
    
            public bool IsCopied()
            {
                //...........Your Logic is Here
                return false;
            }
        }
