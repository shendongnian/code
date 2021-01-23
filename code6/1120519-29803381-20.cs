    public string returnTicket(collection b)
    {
         // map the string to a DAL.collection
         var collection = new DAL.collection();
         collection.SupportRef1 = selectedValue;
         // call the existing method that takes a DAL.collection
         returnTicket(b);
    }
