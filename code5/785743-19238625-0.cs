    protected override bool BeforeSaveEntity(EntityInfo entityInfo) {
            // Return false if don´t want to  save the entity
            var entityType = entityInfo.Entity.GetType();
            if (entityInfo.Entity.GetType() == typeof(MyEntityTypeModel))
            {
                if (entityInfo.EntityState == EntityState.Added)
                // It can be 'Modified' or 'Deleted'
                {
                    var MyModel = entityInfo.Entity as MyEntityTypeModel;
                    MyModel.CreatedDate = DateTime.Now;
                    MyModel.UpdatedDate = DateTime.Now;
                    string username = Membership.GetUser().UserName;
                    MyModel.CreatedBy = username;
                    MyModel.UpdatedBy = username;
                }
            }
            return true;
       }
