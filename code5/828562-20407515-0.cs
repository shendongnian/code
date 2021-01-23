    // assuming System.Windows.Forms.Clipboard
    static void WaitForClipboardChange()
    {
        Clipboard.SetText("xxPlaceholderxx");
        while (Clipboard.GetText() == "xxPlaceholderxx" 
		|| string.IsNullOrWhiteSpace(Clipboard.GetText()))
            Thread.Sleep(90);
    }
