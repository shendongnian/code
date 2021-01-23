     protected void DgrMemberList_ItemDataBound(object sender, DataGridItemEventArgs e)
     {
          if (e.Row.DataItem == null)
              return;
          
          HtmlAnchor aDelivery = e.Item.FindControl("aDelivery") as HtmlAnchor;
          if (e.Item.Cells[2].Text.ToString() == "STK")
          {
               aDelivery.HRef = "CreateDownloadImageSubmit.aspx?OID=" + e.Item.Cells[0].Text;
          }
          else
          {
               aDelivery.HRef = "javascript:void(0);";
          }
    
     }
