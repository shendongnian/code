    <div>
     <a href="#" class="test" id="tester" runat="server" visible='<%# isVisible %>'> Mina Na!
     <sc:FieldRenderer FieldName="Value" runat="server" ID="thelist" Item="<%# thelistID %>" /></a>
    </div>
     FieldRenderer thelistID = (FieldRenderer)e.Item.FindControl("thelistID");
            HtmlAnchor test = (HtmlAnchor)e.Item.FindControl("tester");
            if (AddToList == null || AddToList.Count == 0)
            {
               isVisible = false;
            }
            else
            {
                isVisible = true;
                thelistID.Item = AddToList;
            }
