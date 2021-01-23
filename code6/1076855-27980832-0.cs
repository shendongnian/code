    public class ETextBox : System.Windows.Forms.TextBox
    {
        protected override void OnKeyDown(System.Windows.Forms.KeyEventArgs e)
        {
            if (hotKeyPressed) // this is the condition when you don't want to write in text.
            {
                //Do whatever you want to do in this case.
            }
            else
            {
                base.OnKeyDown(e);
            }
        }
    }
