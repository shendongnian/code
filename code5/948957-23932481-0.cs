    public class Typewriter
    {
        Message message = new Message();
        Page currentPage = new Page();
        Line currentLine = new Line();
        public Typewriter NewPage()
        {
            currentPage = new Page();
            message.Pages.Add(currentPage);
            return NewLine();
        }
        public Typewriter NewLine()
        {
            currentLine = new Line();
            currentPage.Lines.Add(currentLine);
            return this;
        }
        public Typewriter AppendText(string text)
        {
            currentLine.Text.Append(text);
            return this;
        }
    }
