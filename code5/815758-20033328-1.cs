    public IQueryable<Entity.MedicalEntities> GetAll(Entity.MedicalEntities Entity)
    {
        IQueryable<Entity.MedicalEntities>  result = from mID in Entity.Medicals
                     join cs in Entity.Cities on mID.CityFK equals cs.CityID
                     join reg in Entity.Regions on cs.RegionFK equals reg.RegionID
                     //insert actual real entity name for Entity.MedicalEntity
                     select new Entity.MedicalEntity
                     {
                         medicalName = mID.medicalName,
                         MedicalID = mID.MedicalID,
                         CityName = cs.CityName,
                         CityID = cs.CityID,
                         RegionName = reg.RegionName,
                         RegionID = reg.RegionID
                     };
        return result;
    }
