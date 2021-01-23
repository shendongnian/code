     r1.Text = r1.Text + Environment.NewLine;
     r1.SelectAll();
     r1.Copy();
     RichTextBox temp = new RichTextBox();
     temp.Paste();
     r2.SelectAll();
     r2.Copy();
     temp.Paste();
    
     temp.SaveFile(path);
