    class CityFilter : AFilterSetBase<IObjectBase> {
        public CityFilter(string filterName) {
            this.FilterName = filterName;
            this.Filters = new List<IObjectBase>();
        }
    }
    public class CityManager : IFilterSetManager {
        public AFilterSetBase<IObjectBase> Initialize(IClient client) {
            var item = new CityFilter("City Filters");
            item.Filters.Add(new CityBase());
            return item;
        }
    }
