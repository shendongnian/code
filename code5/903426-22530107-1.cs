    SelectUser(userGuid);
    private void SelectUser(Guid userId)
    {    
     BusinessEntityCollection users = LoadUsers();//Load all users
        for (int i = 0; i < users.BusinessEntities.Count; i++)
        {
            DynamicEntity entity = (DynamicEntity)users.BusinessEntities[i];
            if (entity.Properties.Contains(“systemuserid”) && ((Key)entity.Properties["systemuserid"]).Value == userId)
            {
                DDLUsers.Items.Add(new ListItem(entity.Properties["fullname"].ToString(), ((Key)entity.Properties["systemuserid"]).Value.ToString()));
                DDLUsers.Items[i].Selected = true;
            }
            else
            {
                DDLUsers.Items.Add(new ListItem(entity.Properties["fullname"].ToString(), ((Key)entity.Properties["systemuserid"]).Value.ToString()));
             
            }
 
        }
      }
