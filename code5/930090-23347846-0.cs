    <asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <asp:Button ID="Button3" runat="server" Style="position: static" Text="Button" OnClick="Button1_Click" />
    <asp:Button ID="Button2" runat="server" CausesValidation="False" OnClick="Button2_Click" Style="position: static; display: none" Text="Ok" />
    <asp:Button ID="Button5" runat="server" CausesValidation="False" OnClick="Button5_Click" Style="position: static; display: none" Text="Cancel" />
    script type="text/javascript">
            function confirmProcess()
            {
                if (confirm('are you sure to continue?'))
                {
                   //if you are missing this, always use ClientID to get reference to button //control when used with master pages
                    document.getElementById('<%=Button2.ClientID%>').click();
                }
                else
                {
                    document.getElementById('<%=Button5.ClientID%>').click();
                }
                
    
            }
        </script>
    </asp:Content>
