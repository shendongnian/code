    protected override void OnTextChanged(EventArgs e)
    {
        // Get first and last displayed character
        int start = this.GetCharIndexFromPosition(new Point(0, 0));
        int end = this.GetCharIndexFromPosition(new Point(this.ClientSize.Width, this.ClientSize.Height));
    
        // Save cursor position
        int cursor_position = this.SelectionStart;
        int cursor_lenght = this.SelectionLength;
    
        // Your formatting
        Highlight();
    
        // Scroll to the last character and then to the first + line width
        this.SelectionLength = 0;
        this.SelectionStart = end;
        this.ScrollToCaret();
        this.SelectionStart = start + this.Lines[this.GetLineFromCharIndex(start)].Length+1;
        this.ScrollToCaret();
    
        // Finally, set cursor to original position
        this.SelectionStart = cursor_position;
    }
