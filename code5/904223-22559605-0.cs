    //for copy
    var clipboard = (ClipboardManager)GetSystemService(ClipboardService);
    var clip = ClipData.NewPlainText("your_text_to_be_copied");
    clipboard.PrimaryClip = clip;
    // And paste it
    var clipboard = (ClipboardManager)GetSystemService(ClipboardService);
    var pasteData = "";
    if (!(clipboard.HasPrimaryClip)) 
    {
        // If it does contain data, decide if you can handle the data.
    } 
    else if (!(clipboard.PrimaryClipDescription.HasMimeType(ClipDescription.MimetypeTextPlain)))
    {
        // since the clipboard has data but it is not plain text
    } 
    else 
    {
        //since the clipboard contains plain text.
        var item = clipboard.PrimaryClip.GetItemAt(0);
        // Gets the clipboard as text.
        pasteData = item.Text;
    }
