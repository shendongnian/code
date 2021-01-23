      BsonClassMap.RegisterClassMap<Role>(cm =>
      {
         cm.AutoMap();// Automap the Role class
         cm.UnmapProperty(c => c.RoleId); //Ignore RoleId property
         cm.UnmapProperty(c => c.CreateDate);//Ignore CreateDate property
      });
