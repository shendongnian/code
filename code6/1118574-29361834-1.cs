    <asp:Panel runat="server" ID="pnlTextboxes"></asp:Panel>
    
     foreach (string Id in controlidlist)
        {
            i++;
            TextBox tb = new TextBox();
            tb.ID = Id;
            LiteralControl lineBreak = new LiteralControl();
            pnlTextboxes.Controls.Add(tb);
            pnlTextboxes.Controls.Add(lineBreak);
        }
