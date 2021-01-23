    public void SaveSettings(SaveDomainModel model)
    {
        var settings = MapDomainModelToList(model).AsQueryable();
        _repository.UpdateCollection(settings);
    }
    private IEnumerable<DataObj> MapDomainModelToList(SaveDomainModel saveDomainModel)
    {
        var settings = new List<Setting>();
        foreach (var domainModel in saveDomainModel.DomainModels)
        {
            var setting = GetSetting(domainModel.Key, saveDomainModel.SettingType);
            if (!String.Equals(setting.Value, domainModel.Value, StringComparison.CurrentCultureIgnoreCase))
            {
                setting.Value = domainModel.Value;
                setting.LastUpdated = DateTime.Now;
                settings.Add(setting);
            }
        }
        return settings;
    }
    public bool UpdateCollection(IQueryable<T> entities)
    {
        using (var transaction = _session.BeginTransaction())
        {
            foreach (var entity in entities)
            {
                _session.Update(entity);
            }
            transaction.Commit();
        }
        return true;
    }
