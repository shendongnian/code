    public bool Card_Gen(int id) {
    
        int k =0;
        try
        {
            for (k = 1; k <= id; k++)
            {                                  
                    Card_Details New_Card = new Card_Details();
                    New_Card.Card_Num = CreateMD5Hash(Card_Number()).Substring(0, 12);
                    New_Card.Card_Serial = Card_Serial();
                    db.Card_Details.AddObject(New_Card);
                    db.SaveChanges();
             }
        }
        catch (Exception ex) {
            return false;
        }
        return true;
    }
