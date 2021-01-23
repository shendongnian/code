    public class ViewMapper<TModel, TDomain> : IViewMapper<TModel, TDomain>
    {
        public TDomain MapToDomain(TModel dataItem)
        {
            return Mapper.Map<TModel, TDomain>(dataItem);
        }
        public List<TDomain> MapToDomain(IEnumerable<TModel> dataItems)
        {
            return dataItems.Select(this.MapToDomain).ToList();
        }
        public TModel MapToData(TDomain domainItem)
        {
            return Mapper.Map<TDomain, TModel>(domainItem);
        }
        public void MapToOriginalData(TDomain domainItem, TModel dataItem)
        {
            Mapper.Map(domainItem, dataItem);
        }
        public List<TModel> MapToData(IEnumerable<TDomain> domainItems)
        {
            return domainItems.Select(this.MapToData).ToList();
        }
    }
