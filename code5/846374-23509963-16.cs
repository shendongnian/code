    [WebMethod] //this method is static and i use web method because i call this method from client side
    public static void AddMessage(string Date, string Subject, string Body, string Follower, string Department)
    {
        try
        {
            using (DBContext reposit = new DBContext())
            {
                msge <yourEntity> Newmsg = new msge();
                Newmsg.MDate = Date;
                Newmsg.MSubject = Subject.Trim();
                Newmsg.MBody = Body.Trim();
                Newmsg.FID= 5;
                reposit.addmessage(Newmsg);
            }
        }
        catch (Exception)
        {
            throw;
        }
    }
