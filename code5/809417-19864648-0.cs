    private void RichEditBox_KeyDown(object sender, KeyRoutedEventArgs e)
    {
        var state = Window.Current.CoreWindow.GetKeyState(Windows.System.VirtualKey.Control);
        if ((state & CoreVirtualKeyStates.Down) == CoreVirtualKeyStates.Down)
        {
            if (e.Key == Windows.System.VirtualKey.B)
            {
                if (Editor.Document.Selection.Text.Length > 0)
                {
                    // text is selected. make it bold
                    ITextCharacterFormat format = 
                         Editor.Document.Selection.CharacterFormat;
                    format.Bold = FormatEffect.On;
                    var start_pos = Editor.Document.Selection.StartPosition;
                    Editor.Document.Selection.StartPosition = 
                         Editor.Document.Selection.EndPosition;
                    format.Bold = FormatEffect.Off;
                    // Editor.Document.Selection.StartPosition = start_pos;   
                    // this is where I was re-selecting the text after switching bold OFF
                    // but doing so switches it back on again. which makes no sense                     
                }
                else
                {
                    // no text selected. just enable bold mode
                    ITextCharacterFormat format = 
                         Editor.Document.Selection.CharacterFormat;
                    format.Bold = FormatEffect.Toggle;
                }   
            }
        }
    }
