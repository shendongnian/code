    protected void CheckTextBox(object sender, EventArgs e)
            {
                if (string.IsNullOrEmpty(textBox1.Text) && string.IsNullOrEmpty(textBox2.Text))
                {
                    label5.Visible = true;
                }
        
                else
                {
                    label5.Visible = false;
                }
            }
 
    <asp:TextBox ID="TextBox1" runat="server" OnTextChanged="CheckTextBox"></asp:TextBox>
