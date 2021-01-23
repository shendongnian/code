    [ModelBinder(typeof(BindFromJsonModelBinder))]
    public class MyModel
    {
        public int Id { get; set; }
        public string Text { get; set; }
        [BindFromJson]
        public IEnumerable<MyChildModel> Items { get; set; }
    }
