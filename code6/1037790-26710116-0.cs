    public class MyModel
    {
       [JsonConverter(typeof(DataTableConverter))]
       public DataTableRequest DataTableRequest { get; set; }
       // other properties 
    }
