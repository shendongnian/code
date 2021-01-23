    static void Main(string[] args)
    {
        Console.WriteLine("Please copy something into the clipboard.");
        string text = WaitForClipboardChange();
        Console.WriteLine("You copied " + text);
    }
    static string WaitForClipboardChange()
    {
        string placeholderText = "xxPlaceholderxx";
        Clipboard.SetText(placeholderText);
    
        string text = null;
        do 
        {
            Thread.Sleep(90);
            text = Clipboard.GetText();
        }
        while (string.IsNullOrWhiteSpace(text) || text.Equals(placeholderText));
        
        return text;
    }
