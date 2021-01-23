    private int m_CurrTexboxYPos = 10;
    private List<TextBox> m_TextBoxList = new List<TextBox>();
    private void CreateCheckBox()
    {
        m_CurrTexboxYPos += 25;
        TextBox textbox = new TextBox();
        textbox.Location = new System.Drawing.Point(0, m_CurrTexboxYPos);
        textbox.Size = new System.Drawing.Size(100,20);
        m_TextBoxList.Add(textbox);
    }
