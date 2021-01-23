    <ul ID="rbl_items" runat="server" clientidmode="Static" style="list-style: none;"></ul>
    Code Behind:
    
    int count = 0;
    foreach (var yourObj in YourList)
            {
                HtmlGenericControl li = new HtmlGenericControl("li");
                HtmlInputRadioButton radioButton = new HtmlInputRadioButton
                {
                    Value = yourObj,
                    Name = "controlGroup",
                    ID = "controlID" + count
                };
                li.Controls.Add(radioButton);
                Label label = new Label { Text = yourObj, CssClass = "YourCSSClass", AssociatedControlID = "controlID"+count };
                li.Controls.Add(label);
                rbl_items.Controls.Add(li);
                count++;
            }
