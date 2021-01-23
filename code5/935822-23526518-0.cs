    private void myButtonClick(object sender, EventArgs e)
    {
       string[] id = sender.ID.Split(new string[]{"_"}, StringSplitOptions.None);
       string textbox_ID = "txtCantitate" + "_" + id[1] + "_" + id[2];
       TextBox txt = this.Controls.FindControl(textbox_ID) as TextBox;
       int val = -1;
       string finaltext = "";
       if(int.TryParse(txt.Text, out val))
          finaltext = (val-1).ToString();
       else
          finaltext = "Invalid number, Cannot decrement!";
       
       txt.Text = finaltext;
    }
