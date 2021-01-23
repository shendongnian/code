    List<string> notInanswerList = new List<string>();
    foreach (textbox t in Panel1.Controls.OfType<TextBox>())
    {
    choiceList.Add(t.Text.Trim());
    if (!answerList.Contain(t.Text.Trim()))
    {
    notInanswerList.Items.Add(t.Text.Trim());
    t.BackColor = System.Drawing.Color.Red; // changes the textBox BackColor
    }
    }
