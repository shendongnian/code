    private class MyEntity
    {
      public int ID {get;set;}
      public String String1 {get;set;}
      public String String2 {get;set;}
    }
    public class Repository
    {
        List<MyEntity> myEntityCollection{get;set;}
        List<MyEntity> MyEntityCollection
        {
            get
            {
                if (myEntityCollection == null) { LoadAndFillMyEntityCollectionFromDatabase(); } 
                return myEntityCollection;
            }
        }
        public MyEntity GetMyEntity(int id)
        {
            return MyEntityCollection.FirstOrDefault(x=>x.ID == id);
        }
    }
