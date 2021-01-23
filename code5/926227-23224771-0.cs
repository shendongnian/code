    void Main()
    {
        var step = JsonConvert.DeserializeObject<Step>(s);
        Console.WriteLine(((GridInput)step.Input).RowList.Count); // 2
    }
    public class GridHeader { }
    public class ActivityElement { public string Type { get; set; } }
    public class Step : ActivityElement
    {
        public Step()
        {
            this.Id = Guid.NewGuid();
            this.Label = "Basic Step";
            this.Type = "step";
        }
    
        public Guid Id { get; set; }
        public string Label { get; set; }
        public Input Input { get; set; }
    }
    [JsonConverter(typeof(InputJsonConverter))]
    public abstract class Input
    {
        public string Type { get; set; }
        public object Value { get; set; }
    }
    
    public class TextInput : Input
    {
        public TextInput()
        {
            this.Type = "text";
        }
    }
    public class GridInput : Input
    {
        public GridInput()
        {
            this.Type = "grid";
            this.GridHeader = new GridHeader();
            this.RowList = new List<GridRow>();
        }
    
        public GridHeader GridHeader { get; set; }
        public List<GridRow> RowList { get; set; }
    }
    
    public class GridRow
    {
        public GridRow()
        {
            this.IsDeleted = false;
            this.CellList = new List<GridCell>();
        }
    
        public List<GridCell> CellList { get; set; }
        public bool IsDeleted { get; set; }
    }
    
    public class GridCell
    {
        public GridCell()
        {
            this.name = "not set yet";
            this.Input = null;
        }
    
        public string name { get; set; }
        public Input Input { get; set; }
    }
    public abstract class JsonCreationConverter<T> : JsonConverter
    {
        protected abstract T Create(Type objectType, JObject jObject);
    
        public override bool CanConvert(Type objectType)
        {
            return typeof(T).IsAssignableFrom(objectType);
        }
    
        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            // Load JObject from stream
            JObject jObject = JObject.Load(reader);
    
            // Create target object based on JObject
            T target = Create(objectType, jObject);
    
            // Populate the object properties
            serializer.Populate(jObject.CreateReader(), target);
    
            return target;
        }
        public override void WriteJson(
    	JsonWriter writer,
    	Object value,
    	JsonSerializer serializer
    )
        {
            throw new NotImplementedException();
        }
    }
    public class InputJsonConverter : JsonCreationConverter<Input>
    {
        protected override Input Create(Type objectType, JObject jObject)
        {
            var type = (string)jObject.Property("Type");
            switch (type)
            {
                case "grid":
                    return new GridInput();
                case "text":
                    return new TextInput();
    //            case "dropdown":
    //                return new DropdownInput();
    //            case "checkbox":
    //                return new CheckboxInput();
            }
    
            throw new ApplicationException(String.Format("The given type {0} is not supported!", type));
        }
    }
    string s = @"{
        ""Id"":""e833ceae-57e5-4c52-8d56-b047790cb7c7"",
        ""Label"":""Grid time!"",
        ""Input"":
        {
            ""GridHeader"":{""ColumnDefinitionList"":[{""field"":""column1"",""title"":""Column 1""},{""field"":""column2"",""title"":""Column 2""},{""field"":""column3"",""title"":""Column 3""},{""field"":""column4"",""title"":""Column 4""}]},
            ""RowList"":
            [
                {
                    ""CellList"":
                    [
                        {""name"":""column1"",""Input"":{""Type"":""text"",""Value"":""cell 1 row 1""}},
                        {""name"":""column2"",""Input"":{""Type"":""text"",""Value"":""cell 2 row 1""}},
                        {""name"":""column3"",""Input"":{""Type"":""text"",""Value"":""cell 3 row 1""}},
                        {""name"":""column4"",""Input"":{""Type"":""text"",""Value"":""cell 4 row 1""}}
                    ],
                    ""IsDeleted"":false
                },
                {
                    ""CellList"":
                    [
                        {""name"":""column1"",""Input"":{""Type"":""text"",""Value"":""cell 1 row 2""}},
                        {""name"":""column2"",""Input"":{""Type"":""text"",""Value"":""cell 2 row 2""}},
                        {""name"":""column3"",""Input"":{""Type"":""text"",""Value"":""cell 3 row 2""}},
                        {""name"":""column4"",""Input"":{""Type"":""text"",""Value"":""cell 4 row 2""}}
                    ],
                    ""IsDeleted"":false
                }
            ],
            ""Type"":""grid"",
            ""Value"":null
        },
        ""DisplayPosition"":2,
        ""Type"":""step""
    }";
