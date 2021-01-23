    string acctNumber = Request["acctNum"];
    if (member.findAcct(acctNumber, "CheckImage") != null)
    {
         try
         {
             Response.ContentType = "image/jpeg";
             Response.BinaryWrite(((Member)member).checkImage(acctNumber, Request["ckNum"],DateTime.Parse(Request["date"]), Request["amt"], Request["checkSide"]));
         }
         catch (Exception ex)
         {
             Response.ContentType = "text";
             Response.Write("Error retrieving check image: "+ ex.Message);
         }
    }
    else
    {
             Response.ContentType = "text";
             Response.Write("Error retrieving check image: ");
    }
