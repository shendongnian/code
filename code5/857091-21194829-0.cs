    public class InputContext
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public string RouteName { get; set; }
        public DateTime TimeStamp { get; set; }
        //...
    }
    public class RecipeInput
    {
        public int Id { get; set; }
        public int ContextId { get; set; }
        // ...
    }
    public class VariationInput
    {
        public int Id { get; set; }
        public int ContextId { get; set; }
        // ...
    }
