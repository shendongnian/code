        <telerik:RadCodeBlock ID="RadCodeBlock1" runat="server">
        <script type="text/javascript">
            function ViewCheck(filename) {
                var targetfile = "Allegati/" + <%# hfrecordID.value %>  + filename;
                var openWnd = radopen(targetfile, "RadWindowDetails");
            }
        </script>
    
    
     protected void RadGrid1_ItemDataBound(object sender, GridItemEventArgs e)
    {
      if (e.Item is GridEditableItem && e.Item.IsInEditMode)
        {
            GridEditableItem editedItem = e.Item as GridEditableItem;
            hfrecordID= editedItem.GetDataKeyValue("TransazioneID").ToString();
        }
      }
