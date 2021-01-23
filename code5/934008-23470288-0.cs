    <ul ID="rbl_items" runat="server" clientidmode="Static" style="list-style: none;"></ul>
    Code Behind:
    foreach (var yourObj in YourList)
            {
                HtmlGenericControl li = new HtmlGenericControl("li");
                HtmlInputRadioButton radioButton = new HtmlInputRadioButton
                {
                    Value = region,
                Name = "region"
                };
                li.Controls.Add(radioButton);
                Label label = new Label { Text = region, CssClass = "YourCSSClass" };
                li.Controls.Add(label);
                rbl_items.Controls.Add(li);
            }
