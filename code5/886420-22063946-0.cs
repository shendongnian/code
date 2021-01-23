    public class ListView<T> : Dictionary<string, object> where T : IDomainObjectBase
    {
        public ListView(DTOList<T> dto, ICallContext context, string name, IEnumerable<object> items)
        {
            this.Add("header", new ViewListHeader(dto.Total, dto.Page, dto.PageSize, context.LocalPath));
            this.Add(name, items.ToList());
        }
    }
