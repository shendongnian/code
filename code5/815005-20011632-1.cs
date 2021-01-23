    public sealed class MyNamedObject : NamedObject<MyNamedObject>
    {
        protected override string GetClassName()
        {
            return "Full name of MyNamedObject";
        }
    }
