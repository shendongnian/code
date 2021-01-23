    List<Cont> ContCollection =  new List<Cont>();
    foreach (DataRow dr in dt.Rows)
    {
        foreach (DataColumn col in dt.Columns)
        { 
            ContCollection.Add(new Cont(){
                                sno = dr["Cinema"].ToString(), 
                                name = dr["Gallery"].ToString(), 
                                address =  dr["star"].ToString(), 
                                gender =  dr["video"].ToString(), 
                                em = dr["em"].ToString(),
                                phone=new Phone { mobile=dr["phonone"].ToString() }
                               });
                 
                      
        }
        objectToSerialize.contacts = ContCollection;
        JavaScriptSerializer serializer = new JavaScriptSerializer();
        Response.Write(serializer.Serialize(new { item = objectToSerialize.contacts }));
    }
