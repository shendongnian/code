    for (int i = this.Controls.Count - 1; i >= 0; i--)
    {
        Control c = this.Controls[i];
        if (c.GetType() == typeof (Button))
        {
            c.Click -= new EventHandler(TeamChoiceButton_Click);
            this.Controls.RemoveAt(i);
            c.Dispose();
        }
    }
