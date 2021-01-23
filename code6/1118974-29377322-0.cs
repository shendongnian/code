    string FindOrganizationName(OrganizationEntity entity, int entityType)
    {
        if (entity == null)
        {
            return null;
        }
        else if (entity.OrganizationEntityTypeId == entityType)
        {
            return entity.Name;
        }
        else
        {
            return FindOrganizationName(entity.Parent, entityType);
        }
    }
