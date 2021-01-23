    public class AnotherClass
    {
        public void YourMethodThatAccessTextBox(TextBox t)
        {
                // do something interesting with t;
        }
    }
    
    In your OK button
    
    ok_click
    {
       AnotherClass ac = new AnotherClass().YourMethodThatAccessTextBox(txtValue);
    }
