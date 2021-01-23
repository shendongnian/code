    protected void ASPxGridView2_CustomColumnDisplayText(object sender,
        DevExpress.Web.ASPxGridViewColumnDisplayTextEventArgs e) {
        if (e.Column.FieldName != "FormatType") return;
        e.DisplayText = WebApp.Helpers.CodebooksHelper.GetItemData(1).First(item => item.ItemID == (int)e.Value).Title;
    }
    settings.CustomColumnDisplayText += (sender, e) => {
            if (e.Column.FieldName != "FormatType") return;
            e.DisplayText = WebApp.Helpers.CodebooksHelper.GetItemData(1).First(item => item.ItemID == (int)e.Value).Title;
    }
