    foreach (DataRow row in rsltFromSql.Rows)
    {
        ActivityMimeAttachment attachmentMimeTemp;
        try
        {
            attachmentMimeTemp = (ActivityMimeAttachment)handlerCrm.CrmService.Retrieve(ActivityMimeAttachment.EntityLogicalName, Guid.Parse(row["ActivityMimeAttachmentId"].ToString()), new ColumnSet(true));
        }
        catch (Exception ex)
        {
             /////
        }
        //delete body field
        attachmentMimeTemp.Body = null;
        //update the attachment with body = null
        handlerCrm.CrmService.Update(attachmentMimeTemp);
        attachmentMimeGuidList.Add(new Guid(row["ActivityMimeAttachmentId"].ToString()));
    }
