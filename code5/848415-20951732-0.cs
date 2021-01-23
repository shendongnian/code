    var list = web.Lists[specificList];
    var contentType = list.ContentTypes["Document"]
    foreach (SPField field in contentType.Fields)
    {
        if(!field.Reorderable || contentType.FieldLinks[field.Id].Hidden)
        { 
            continue;
        }
        
        //Process fields
    }
