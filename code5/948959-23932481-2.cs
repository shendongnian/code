    public class Typewriter
    {
        Message message = new Message();
        Page currentPage;
        public Typewriter NewPage()
        {
            currentPage = new Page();
            message.Pages.Add(currentPage);
            return this;
        }
        public Typewriter AddLine(string text)
        {
            currentPage.Lines.Add(new Line() { Text = text });
            return this;
        }
    }
