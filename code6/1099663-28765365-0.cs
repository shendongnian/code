    <asp:CheckBoxList ID="CheckBoxList1" runat="server" DataSourceID="LinqDataSource2" DataTextField="ProjectGroupTitle" DataValueField="ProjectGroupID" OnDataBound="SelectCheckbox"></asp:CheckBoxList> 
      
     public void SelectCheckbox(object sender, EventArgs e)
            {
                for (int i = 0; i < CheckBoxList1.Items.Count; i++)
                            {
                                if (CheckBoxList1.Items[i].Text == j.ProjectGroupTitle)
                                {
                                    CheckBoxList1.Items[i].Selected = true;
                                }
                            }
        }
