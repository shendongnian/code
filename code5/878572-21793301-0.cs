    [ModelBinder(typeof(MyCustomModelBinder))]
    public class MyModelClass
    {
        public class MyCustomModelBinder : DefaultModelBinder
        {
            ...
        }
        ...
    }
