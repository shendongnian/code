    public class MyRichTextBox : RichTextBox
    {
        protected override void OnMouseMove(MouseEventArgs e)
        {
            //get the word under the cursor
            var word = Helper.GetWordUnderCursor(this, e);
            if (string.Equals(word, "Hello"))
            {
                //let RichTextBox raise the event
                base.OnMouseMove(e);
            }
        }
    }
