    [ModelBinder(typeof(AliasBinder))]
    public class MyModel
    {
        [Alias("state")]
        public string Status { get; set; }
    }
