    void OnKeyDown(object sender, KeyEventArgs e)
    {
        switch (e.KeyCode)
        {
            case Keys.Left:
            case Keys.Right:
            {
                int lastline = richTextbox1.Lines.Length - 1;
                int first = richTextbox1.GetFirstCharIndexFromLine(lastline);
                int valid = first + root.Length + 1;
    
                if (richTextbox1.SelectionStart < valid )
                {
                    //richTextbox1.Select(valid, 0);
                    //richTextbox1.Invalidate();
                    e.Handled = true;
                }
            }
            break;
        }
    }
