     public bool Card_Gen(int id) {
        Card_Details New_Card ;
        int k =0;
        try
        {
            for (k = 1; k <= id; k++)
            {
                    //creating new object in loop
                    New_Card = new Card_Details();
                                      
                    New_Card.Card_Num = CreateMD5Hash(Card_Number()).Substring(0, 12);
                    New_Card.Card_Serial = Card_Serial();
    
                    //edit in these two lines if you are using LINQ2SQL otherwise for other providers your code might be correct 
                    db.Card_Details.InsertOnSubmit(New_Card);
                    db.SubmitChanges();
             }
        }
        catch (Exception ex) {
            return false;
        }
        return true;
    }
