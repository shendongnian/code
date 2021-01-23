    <script src="https://ajax.googleapis.com/ajax/libs/jquery/1.10.2/jquery.min.js"></script>
    <!DOCTYPE html>
    <html xmlns="http://www.w3.org/1999/xhtml">
    <head runat="server">
        <title></title>
        <script type="text/javascript">
            function isNumberKey(evt) {
                var charCode = (evt.which) ? evt.which : event.keyCode
                if (charCode > 31 && (charCode < 48 || charCode > 57))
                    return false;
                return true;
            }
            function validateTextBox() {
                ValidateCheckBox()
                //get target base & child control.
                var TargetBaseControl = document.getElementById('<%=this.gv1.ClientID%>');
                var TargetChildControl1 = "text1";
                //get all the control of the type INPUT in the base control.
                var Inputs = TargetBaseControl.getElementsByTagName("input");
                for (var n = 0; n < Inputs.length; ++n)
                    if (Inputs[n].type == 'text' && Inputs[n].id.indexOf(TargetChildControl1, 0) >= 0)
                        if (Inputs[n].value != "") return true;
                alert('Enter some value in textbox!');
                return false;
            }
            function ValidateCheckBox() {            
                //get target base & child control.
                var TargetBaseControl = document.getElementById('<%=this.gv1.ClientID%>');
               var TargetChildControl = "check1";    //get all the control of the type INPUT in the base control.
               var Inputs = TargetBaseControl.getElementsByTagName("input");
               for (var n = 0; n < Inputs.length; ++n)
                   if (Inputs[n].type == 'checkbox' && Inputs[n].id.indexOf(TargetChildControl, 0) >= 0)
                       if (Inputs[n].checked) return true;
               alert('Select at least one checkbox!');
               return false;
           }
        </script>
        <style type="text/css">
            .auto-style1 {
                text-decoration: underline;
            }
        </style>
    </head>
    <body>
        <form id="form1" runat="server">
            <div>
                <div>
           <center>
            <asp:GridView ID="gv1" AutoGenerateColumns="False" 
                runat="server" Height="115px" Width="373px" OnSelectedIndexChanged="gv1_SelectedIndexChanged" DataSourceID="SqlDataSource1" >
             <Columns>             
                 <asp:TemplateField>
                     <ItemTemplate>
                         <asp:CheckBox ID="check1" runat="server" AutoPostBack="true"  />
                     </ItemTemplate>
                 </asp:TemplateField>             
                 <asp:BoundField HeaderText="ProductId" DataField="ProductId" InsertVisible="False" ReadOnly="True" SortExpression="ProductId" />
                 <asp:BoundField HeaderText="ProductName" DataField="ProductName" SortExpression="ProductName" />
                 <asp:BoundField HeaderText="Price" DataField="Price" SortExpression="Price" />
                 <asp:TemplateField HeaderText="Enter Quantity">
                     <ItemTemplate>
                         <asp:TextBox ID="text1" runat="server" MaxLength="10" Onkeypress="return isNumberKey(event)"/>    
                     </ItemTemplate>
                 </asp:TemplateField>
                 <asp:TemplateField HeaderText="Total">
                     <ItemTemplate>
                        <asp:Label ID="lbltotal1" runat="server" Text="Label"></asp:Label>  
                     </ItemTemplate>
                 </asp:TemplateField>              
             </Columns>
            </asp:GridView>
                <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:BaviConnectionString %>" SelectCommand="SELECT [ProductId], [ProductName], [Price] FROM [Product]"></asp:SqlDataSource>
                <asp:Button ID="Button1" runat="server" Text="View" OnClientClick="javascript:return validateTextBox();" OnClick="Button1_Click" />
                </center>
                    <br />
                    <br />
        <center>
        <h><strong><span class="auto-style1">Selected Product</span><br />
        </strong></h>
            &nbsp;<asp:GridView ID="gv2" AutoGenerateColumns="False" runat="server" >
            <Columns>  
             <asp:BoundField HeaderText="ProductName" DataField="ProductName" SortExpression="ProductName" />      
             <asp:BoundField HeaderText="Price" DataField="Price" SortExpression="Price" />
             <asp:BoundField HeaderText="Quantity" DataField="Quantity" SortExpression="Quantity" />
             <asp:BoundField HeaderText="Total" DataField="Total" SortExpression="Total" />       
            </Columns>
            </asp:GridView>
        <br />
        <asp:Label ID="Label1" runat="server" Text="Total Price" ></asp:Label>         
        <asp:TextBox ID="txttotal" runat="server" Width="75px"></asp:TextBox>
        </center>
                </div>
            </div>
        </form>
    </body>
    </html>
     protected void Button1_Click(object sender, EventArgs e)
    {
        DataTable dt = new DataTable();
        dt.Columns.AddRange(new DataColumn[4] {
            new DataColumn("ProductName"),
            new DataColumn("Price"),
            new DataColumn("Quantity"),
            new DataColumn("total")
        });
        foreach (GridViewRow row in gv1.Rows)
        {
            if (row.RowType == DataControlRowType.DataRow)
            {
               
                CheckBox chk = (row.Cells[0].FindControl("check1") as CheckBox);
                string qty = ((TextBox)gv1.Rows[row.RowIndex].FindControl("text1")).Text;[enter image description here][1]
            
                if (chk.Checked)
                {
                    string name = row.Cells[2].Text;
                    string Price = row.Cells[3].Text;
                    string Quantity = qty;                  
                    ((Label)gv1.Rows[row.RowIndex].FindControl("lbltotal1")).Text = Convert.ToString(Convert.ToInt32(qty) * Convert.ToInt32(Price));
                    string Ttl = ((Label)gv1.Rows[row.RowIndex].FindControl("lbltotal1")).Text;
                    tprice += int.Parse(Ttl);
                    dt.Rows.Add(name, Price, Quantity, Ttl);
                }
                
            }
        }
        txttotal.Text = tprice.ToString();
        gv2.DataSource = dt;
        gv2.DataBind();
      
    }
