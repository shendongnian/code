    <asp:Panel runat="server" ID="Panel1">
     ... Your content here
    </asp:Panel>
    <asp:Panel runat="server" ID="Panel2">
     ... Your other content here
    </asp:Panel>
    
    Now in code behind write OnSelectedIndexChanged event
    
    protected void DropDownList2_IndexChanged(object sender,EventArgs e)
    {
      //Now check value of dropdown list and show or hide panel according to it.
      if(DropDownList2.SelectedValue=="1")
      {
      Panel1.Visible=true;
      Panel2.Visible=false;
      }
      else if(DropDownList2.SelectedValue=="2")
      {
       Panel1.Visible=false;
       Panel2.Visible=true;
      }
    }
