    public class CustomTextControl : Control, ITextControl
    {
        private string _text;
    
    	public CustomTextControl() // change this to DivControl
    	{
    	}
    
        public string Text
        {
            get
            {
                return _text;
            }
            set
            {
                if (value != null)
                {
                    _text = value;
                }
                else
                {
                    _text = "No Value.";
                }
            }
        }
    
        // Provide the remaining code to implement a text control.
    }
