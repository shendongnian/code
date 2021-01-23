    public class MyObject : ReactiveObject
    {
        public ReactiveCollection<MySubObject> Objects { get; set; }
        private ObservableAsPropertyHelper<IEnumerable<object>> groupedObjectsHelper;
        public IEnumerable<MySubObject> GroupedObjects
        { 
            get {return groupedObjectsHelper.Value;}
        }
        private ObservableAsPropertyHelper<Decimal> totalOfAllHelper;
        public Decimal TotalOfAll 
        {
            get {return totalOfAllHelper.Value;}
        }
    
        public MyObject()
        {
             var whenObjectsChange=
               Observable.Merge(Objects.Changed.Select(_=>Unit.Default),
                                Objects.ItemChanged.Select(_=>Unit.Default));
             totalOfAllHelper=
               whenObjectsChange.Select(_=>Objects.Sum(o=>o.Value))
                                .ToProperty(this,t=>TotalOfAll);
             groupedObjectsHelper=
               whenObjectsChange.Select(_=>Objects
                                  .GroupBy(o=>o.RowType)
                                  .Select(g=> new {Header=g.Key,
                                                   SubTotal=g.Sum(o=>o.Value),
                                                   Items=g}))
                                .ToProperty(this,t=>t.GroupedObjects);
                                      
        }
    }
