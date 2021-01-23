    // index of highlighted text block
    var i = 0;    
    var timer = new Timer()
    {
        Interval = 300
    };
    timer.Tick += new EventHandler((sender, e) =>
        {
            // split the elements to highlight by space character
            var textElements = this.richTextBox1.Text
                .Split(new char[]{' '}, StringSplitOptions.RemoveEmptyEntries)
                .ToArray();
            // avoid dividing by zero when using modulo operator
            if (textElements.Length > 0)
            {
                // start all over again when the end of text is reached. 
                i = i % textElements.Length;
                
                // clear the RichTextBox
                this.richTextBox1.Text = string.Empty;
            
                for (var n = 0; n < textElements.Length; n++)
                {
                    // now adding each text block again
                    // choose color depending on the index
                    this.richTextBox1.AppendText(textElements[n] + ' ', i == n ? Color.Red : Color.Black);
                }
                // increment the index for the next run
                i++;
            }
        });
        timer.Start();
    
