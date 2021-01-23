        public void deleteStorage(int ID)
    {
        using(DBTicketSystemEntities e = new DBTicketSystemEntities())
        {
          //Like That
            var selectedItem = e.TblNewsStorage.Where( t => t.ID == ID).FirstOrDefault(); 
            e.TblNewsStorage.DeleteObject(selectedItem);
            e.SaveChanges();
        }
    }
