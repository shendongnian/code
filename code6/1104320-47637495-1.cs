    Req req = Globals.Connection.ReqFactory.Item(*ID*));
    VersionControl versionControl = ((IVersionedEntity)req).VC as VersionControl;
    versionControl.CheckOut(string.Empty);
    AttachmentFactory attFac = req.Attachments;
    Attachment att = (Attachment)attFac.AddItem(System.DBNull.Value);
    att.Description = "*Your description here";
    att.Type = (int)TDAPI_ATTACH_TYPE.TDATT_FILE; //for URL, change here
    att.FileName = "*Your path including filename here*";
    att.Post();
    versionControl.CheckIn("*Your check-in comment here*");
