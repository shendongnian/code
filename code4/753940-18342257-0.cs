    MyEntity entity1 = new MyEntity() { FirstName = "Jon", LastName = "Doh" };
    MyEntity entity2 = new MyEntity() { FirstName = "Jon", LastName = "The Great" };
    
    MyEntity diffEntity = new MyEntity
         {
             FirstName = (entity1.FirstName == entity2.FirstName) ? null : entity2.FirstName,
             LastName = (entity1.LastName == entity2.LastName) ? null : entity2.LastName
         };
