    using System.Collections.Generic;
    using System.Collections.ObjectModel;
    using TestSO.model;
    namespace TestSO.controller
    {
        public class GenericController<T>
        {
            private readonly IList<T> collection = new ObservableCollection<T>();
            public IList<T> Collection
            {
                get
                {
                    return collection;
                }
            }
            public GenericController()
            {
            }
        }
        public class CellGridController : GenericController<Cell>
        {
            public CellGridController()
            {
            }
        }
    }
