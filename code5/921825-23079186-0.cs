    @Html.DevExpress().GridView(settings =>
    {
        //General settings
        settings.Name = "name";
        settings.KeyFieldName = "ID";
        //Other settings etc.....
    
        settings.Columns.Add(column =>
        {
            column.Name = "Name";
            column.FieldName = "CurrentFieldBoundToColumn";
            column.Caption = "Some caption";
    
            column.SetDataItemTemplateContent(content =>
                ViewContext.Writer.Write(
                    Html.ActionLink("LinkText", "Action", "Controller",
                    new { ID = content.KeyValue }, null)));
        });
        //Other Columns etc etc
    });
