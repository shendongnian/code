    TextBox dynamicTxtBox = new TextBox();
    dynamicTxtBox.Text = "(enter text)";
    dynamicTxtBox.ID = "dTxtBox";
    Button dynamicBtn = new Button();
    dynamicBtn.Click += new System.EventHandler(dynamicBtn_Click);
    Panel1.Controls.Add(dynamicTxtBox);
    Panel1.Controls.Add(dynamicBtn);
    private void dynamicBtn_Click(Object sender, System.EventArgs e)
    {
    //your code here
    }
