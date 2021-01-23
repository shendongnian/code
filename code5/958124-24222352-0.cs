    {
        CheckTextBox(textbox1);
        CheckTextBox(textbox2);
        CheckTextBox(textbox3);
    }
    void CheckTextBox(TextBox tb)
        {
            if (string.IsNullOrEmpty(tb.Text))
            {
                mbox(tb.Name + "must be filled");
            }
        }
