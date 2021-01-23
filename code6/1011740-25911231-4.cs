    public class TemplateDataLinkedListBase<T> where T : TemplateDataLinkedListBase<T>
    {
        [JsonProperty(TypeNameHandling = TypeNameHandling.Objects)]
        public T Parent { get; set; }
        [JsonProperty(TypeNameHandling = TypeNameHandling.Objects)]
        public List<T> Children { get; set; }
    }
    public class TemplateDataQueryElement : TemplateDataLinkedListBase<TemplateDataQueryElement>
    {
        public string Query { get; set; }
        public TemplateDataQueryElement()
        {
            Children = new List<TemplateDataQueryElement>();
        }
    }
