    enum TextAction
    {
        Clear,
        Append,
        RemoveLast
    }
    private void FormatText(TextAction action, string value = null)
    {
        var textBox = DetermineTextBox();
        if (textBox != null)
        {
            switch (action)
            {
                case TextAction.Append :
                    textBox.Text = value;
                    break;
                case TextAction.Clear:
                    textBox.Text = "";
                    break;
                case TextAction.RemoveLast:
                    textBox.Text = textBox.Text.Remove(textBox.Text.Length - 1, 1);
                    break;
                default:
                    break;
            }
        }
    }
    private TextBox DetermineTextBox()
    {
        if (remainTxt.BackColor == Color.FromArgb(245, 244, 162))
        {
            return remainTxt;
        }
        else if (totalTxt.BackColor == Color.FromArgb(245, 244, 162))
        {
            return totalTxt;
        }
        else if (paidTxt.BackColor == Color.FromArgb(245, 244, 162))
        {
            return paidTxt;
        }
        return null;
    }
    private void btn1_Click(object sender, EventArgs e)
    {
        FormatText(TextAction.Append, "1");
    }
    private void btn2_Click(object sender, EventArgs e)
    {
        FormatText(TextAction.Append, "2");
    }
    private void btn3_Click(object sender, EventArgs e)
    {
        FormatText(TextAction.Append, "3");
    }
    private void btn4_Click(object sender, EventArgs e)
    {
        FormatText(TextAction.Append, "4");
    }
    private void btn5_Click(object sender, EventArgs e)
    {
        FormatText(TextAction.Append, "5");
    }
    private void btn6_Click(object sender, EventArgs e)
    {
        FormatText(TextAction.Append, "6");
    }
    private void btn7_Click(object sender, EventArgs e)
    {
        FormatText(TextAction.Append, "7");
    }
    private void btn8_Click(object sender, EventArgs e)
    {
        FormatText(TextAction.Append, "8");
    }
    private void btn9_Click(object sender, EventArgs e)
    {
        FormatText(TextAction.Append, "9");
    }
    private void btn0_Click(object sender, EventArgs e)
    {
        FormatText(TextAction.Append, "0");
    }
    private void btndot_Click(object sender, EventArgs e)
    {
        FormatText(TextAction.Append, ".");
    }
    private void btnback_Click(object sender, EventArgs e)
    {
        FormatText(TextAction.RemoveLast);
    }
    private void btnreset_Click(object sender, EventArgs e)
    {
        FormatText(TextAction.Clear);
    }
