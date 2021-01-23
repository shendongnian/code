        public MyList Items { get; private set; }
    
        public ICommand Delete { get; private set; }
        
    private void delete(object sender)
    {
     var item = sender as ItemType;
    
     if (item == null)
       return;
      MyList.RemoveOnSubmit(item);
      YourDataContextSQL.SubmitChanges();
    }
