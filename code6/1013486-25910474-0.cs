        protected void Page_Load(object sender, EventArgs e)
        {
            Guid objID = //take the ID of the object ?ID=""
            DataRow attachmentRow = //fetch DataRow of the Attachment from Database
            if (attachmentRow == null)
                return;
            Response.ContentType = attachmentRow["ContentType"].ToString();// value of this is image/gif or image/jpeg and etc.
            Response.BinaryWrite((byte[])attachmentRow["Data"]); // Data is type image in my case                
            Response.End();
        }
