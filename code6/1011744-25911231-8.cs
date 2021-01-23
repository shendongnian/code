    public class TemplateDataLinkedListBase<T> where T : TemplateDataLinkedListBase<T>
    {
        [JsonProperty(TypeNameHandling = TypeNameHandling.Objects)]
        public T Parent { get; set; }
 
        [JsonProperty(TypeNameHandling=TypeNameHandling.Objects)]
        public List<T> Children { get; set; }
        public string EntityName { get; set; }
        public HashSet<string> Fields { get; set; }
 
        public string Key { get { return getKey(); } }
        
        public TemplateDataLinkedListBase()
        {
            Children = new List<T>();
            Fields = new HashSet<string>();
        }
        public TemplateDataLinkedListBase(string entityName)
        {
            EntityName = entityName;
            Children = new List<T>();
            Fields = new HashSet<string>();
        }
 
        private string getKey()
        {
            List<string> keys = new List<string>();
            keys.Add(this.EntityName);
            getParentKeys(ref keys, this);
            keys.Reverse();
            return string.Join(".", keys);
 
        }
 
        private void getParentKeys(ref List<string> keys, TemplateDataLinkedListBase<T> element)
        {
            if (element.Parent != null)
            {
                keys.Add(element.Parent.EntityName);
                getParentKeys(ref keys, element.Parent);
            }
        }
 
        public T AddChild(T child)
        {
            child.Parent = (T)this;
            Children.Add(child);
            return (T)this;
        }
 
        public T AddChildren(List<T> children)
        {
            foreach (var child in children)
            {
                child.Parent = (T)this;
            }
            Children.AddRange(children);
            return (T)this;
        }
 
        public void AddFields(IEnumerable<string> fields)
        {
            foreach (var field in fields)
                this.Fields.Add(field);
        }
 
        public TemplateDataLinkedListBase<T> Find(string searchkey)
        {
            if (this.Key == searchkey)
            {
                return this;
            }
            else
            {
                foreach (var child in Children)
                {
                    if (child.Key == searchkey)
                    {
                        return child;
                    }
                    else
                    {
                        var childResult = child.Find(searchkey);
                        if (childResult != null) return childResult;
                    }
                }
            }
            return null;
        }
    }
    public class TemplateDataQueryElement : TemplateDataLinkedListBase<TemplateDataQueryElement>, ITemplateDataQueryElement
    {
        public string TemplateModelName { get; set; }
        public string RecordId { get; set; }
        public string ParentForeignKeyName { get; set; }
        public string Query { get; set; }
        public dynamic ObjectData { get; set; }
        public ITemplateDataParseResult ParseResult { get; set; }
        
        public TemplateDataQueryElement() : base()
        {
            Fields.Add("Id"); //Always retrieve Id's
            ObjectData = new ExpandoObject();
        }
        
        public TemplateDataQueryElement(string entityName)
            : base(entityName)
        {
            Fields.Add("Id"); //Always retrieve Id's
            ObjectData = new ExpandoObject();
        }
 
        public override string ToString()
        {
            return string.Format("{0}: {1}", EntityName, Query);
        }
    }
