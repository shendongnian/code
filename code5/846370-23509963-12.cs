    public void addmessage(<yourEntity> _msg)
    {
    	var date = new SqlParameter("@date", _msg.MDate);
    	var subject = new SqlParameter("@subject", _msg.MSubject);
    	var body = new SqlParameter("@body", _msg.MBody);
    	var fid = new SqlParameter("@fid", _msg.FID);
    	this.Database.ExecuteSqlCommand("exec messageinsert @Date , @Subject , @Body , @Fid", date,subject,body,fid);
    }
