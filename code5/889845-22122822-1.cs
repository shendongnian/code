    private void AddControl_Click(object sender, EventArgs e)
    {
        var temp = new Button();
        temp.Text = "AAA";
        if (CurrentFlowWidthWidth != flw_chat.ClientSize.Width)
            flw_chat_ClientSizeChanged(null, null);
        temp.Width = CurrentFlowWidthWidth - temp.Margin.Horizontal - 4;
        flw_chat.Controls.Add(temp);
        if (flw_chat.HorizontalScroll.Visible)
            flw_chat.PerformLayout();
    }
