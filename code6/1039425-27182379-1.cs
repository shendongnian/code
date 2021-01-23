     public List<Entity> GetEntities(string entityName)
        {
            OrganizationServiceContext DataContext = new OrganizationServiceContext(ServerConnection.GetOrganizationProxy());
             
            return DataContext.CreateQuery(entityName).toList();
        }
