    [JsonConverter(typeof(FormParamsConverter))]
    public class FormParameters
    {
        public Form Form { get; set; }
    }
    public class Form
    {
        public int Id { get; set; }
    }
