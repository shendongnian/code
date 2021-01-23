    private void SaveRecord()
    {
             using(DBDatacontex DB = new DBDatacontex) {
             //I used this because the SaveRecord function is in the same class as the object used to create the record
             DB.Delivery_HeaderRECs.InsertOnSubmit(this);
             DB.SubmitChanges(); }
    }
}
    
