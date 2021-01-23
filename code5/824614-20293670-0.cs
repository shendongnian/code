    Type objType = yourObject.GetType();
    if (objType == typeof(AttachmentBusinessObject))
    {
        var myAttachBusObject = (AttachmentBusinessObject)yourObject;
        ...
    }
    else
        ...
