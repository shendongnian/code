    [ParseChildren(true), PersistChildren(true), DefaultProperty("Filters")] 
    public class FilteredGridView : GridView 
    { 
        private FilterList _filters;  
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)] 
        [PersistenceMode(PersistenceMode.InnerProperty)] 
        [TemplateContainer(typeof(FilteredGridView))] 
        public FilterList Filters { 
            get { return _filters; } 
            set { _filters = value; } 
        } 
    } 
    public class FilterList : List<Filter> 
    { 
    }
