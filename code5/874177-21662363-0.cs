       <div id="content">
            <asp:Accordion ID="Accordion1" runat="server" SelectedIndex="0" AutoSize="None"
                FadeTransitions="true" TransitionDuration="300" FramesPerSecond="25">
                <Panes>
                    <asp:AccordionPane ID="AccordionPane1" runat="server">
                        <Header>
                            <br />
                            <div class="headPane">
                                Issued History
                            </div>
                        </Header>
                        <Content>
                            <div class="bodyPane">
                                <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                                    <ContentTemplate>
                                        <asp:GridView ID="GridIssue" runat="server" CssClass="grid" AllowPaging="true" PageSize="8" OnPageIndexChanging="GridIssue_PageIndexChanging">
                                            <EmptyDataTemplate>
                                                <p style="margin-left: 10px;">No Book Has Been Issued Yet.</p>
                                            </EmptyDataTemplate>
                                        </asp:GridView>
    
                                    </ContentTemplate>
                                </asp:UpdatePanel>
                            </div>
                        </Content>
                    </asp:AccordionPane>
                    <asp:AccordionPane runat="server" ID="acd2">
                        <Header>
                            <div class="headPane">
                                Restore Books
                            </div>
                        </Header>
                        <Content>
                            <div class="bodyPane">
                               <asp:GridView ID="GridReturned" DataSourceID="sdSource" runat="server" OnSelectedIndexChanged="GridReturned_SelectedIndexChanged">
                                    <EmptyDataTemplate>
                                        <p>Books Are Not Required To Return At Present.</p>
                                    </EmptyDataTemplate>
                                    <Columns>
                                        <asp:CommandField ButtonType="Button" SelectText="Return" ShowSelectButton="true" />
                                    </Columns>
                                </asp:GridView>
                                <asp:SqlDataSource ID="sdSource" runat="server" SelectCommand="select Issue_ID,BID,UserName,BookName,IssueDate,ReturnDate from IssueRecords where ActualReturnDate is null" ConnectionString="<%$ConnectionStrings:connect %>" ></asp:SqlDataSource>
                            </div>
                        </Content>
                       
                    </asp:AccordionPane>
                </Panes>
            </asp:Accordion>
