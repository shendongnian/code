    <asp:TextBox ID="date" runat="server" />
        <asp:ScriptManager ID="Manager" runat="server" />
        <script type="text/javascript">
            function pageLoaded()
            {
                var textBox = document.getElementById( '<% =date.ClientID %>' );
                var submitButton = document.getElementById( '<% =submit.ClientID %>' );
                textBox.onchange = function ()
                {
                    submitButton.disabled = true;
                };
            }
            var prm = Sys.WebForms.PageRequestManager.getInstance();
            prm.add_pageLoaded( pageLoaded );
        </script>
        <asp:UpdatePanel ID="setDate" runat="server" UpdateMode="Conditional" ChildrenAsTriggers="true">
            <ContentTemplate>
                &nbsp;<asp:Label ID="checkRes" runat="server" />&nbsp;<asp:Label ID="range" runat="server" /><br />
                <asp:ImageButton ID="check" runat="server" ImageUrl="http://static.adzerk.net/Advertisers/d18eea9d28f3490b8dcbfa9e38f8336e.jpg"
                    OnClick="check_Click" CausesValidation="false" UseSubmitBehavior="false" />
                <br />
                <asp:Button ID="submit" runat="server" Text="Submit" CausesValidation="true" Enabled="false" />
                
                <asp:UpdateProgress ID="UpdateProgress1" runat="server" AssociatedUpdatePanelID="setDate">
                    <ProgressTemplate>
                        <asp:Image ID="loader" runat="server" ImageUrl="~/img/loader.gif" />
                    </ProgressTemplate>
                </asp:UpdateProgress>
            </ContentTemplate>
            <Triggers>
                <asp:AsyncPostBackTrigger ControlID="check" EventName="Click" />
            </Triggers>
        </asp:UpdatePanel>
