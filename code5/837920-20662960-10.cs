    public interface IDynamicView
    {
         public string Text { get; set; }
         public void AddItemToControlList(SomeItem item);
         // other methods you want to expose (...)
    }
