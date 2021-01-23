    private void BindData()
    { 
        OutLook._Application _app = new OutLook.Application();
        OutLook._NameSpace _ns = _app.GetNamespace("MAPI");
        OutLook.MAPIFolder inbox = _ns.GetDefaultFolder(OutLook.OlDefaultFolders.olFolderInbox);
        _ns.SendAndReceive(true);
        dt = new DataTable("Inbox");
        dt.Columns.Add("Sender", typeof(string));
        dt.Columns.Add("Emails", typeof(string));
        dt.Columns.Add("Subject", typeof(string));
        dt.Columns.Add("Date", typeof(DateTime));        
        dt.Columns.Add("Body", typeof(string));
        int counter = 0;
        int noofemail = 0;
        for (counter = inbox.Items.Count; counter >= 1; counter--)
        {  OutLook.MailItem item = (OutLook.MailItem)inbox.Items[counter];           
                string Reply="";
                string ReplyAll = "";
                string Forward="";
                string Subject="";             
                Reply = string.Format("<a href = 'mailto:{1}' class='btn' style='color:white'>{0}</a>", "Reply", item.SenderEmailAddress);
                ReplyAll = string.Format("<a href = 'mailto:{1},{2}' class='btn' style='color:white'>{0}</a>", "ReplyAll", item.SenderEmailAddress, item.CC);
                Forward = string.Format("<a href = 'mailto:{1}' class='btn' style='color:white'>{0}</a>", "Forward", "");
                Subject = string.Format("<b><span style='color:#000000'>{0}</span></b><b style='float:right;color:#000000'>{1}</b><br><span style='color:#999999'>{2}</span>", item.SenderName, item.SentOn.ToLongTimeString(), item.Subject);           
                dt.Rows.Add(new object[] { item.SenderName,item.SenderEmailAddress,Subject, item.SentOn.ToLongDateString() + " " + item.SentOn.ToLongTimeString(), Reply, ReplyAll, Forward, item.HTMLBody });             
        }
        EnumerableRowCollection<DataRow> rows = null;
        rows = (from row in dt.AsEnumerable()
                where row.Field<DateTime>("Date") > DateTime.Now.AddDays(-30)
                orderby row["Date"] descending
                select row);
        dt.Rows.Add(rows);
       gvEmail.DataSource = dt;
       gvEmail.DataBind();
        }
