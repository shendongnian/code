    public class DataBuilderChild : DataBuilderParent
    {
        private readonly MyChild myChild = new MyChild();
        public DataBuilderChild()
        {
            base.SetDataBuilder(myChild);
        }
        public override DataBuilderParent WithDescription(string description)
        {
            myChild.Description = description;
            return this;
        }
        private MyChild Build()
        {
            return myChild;
        }
        public static implicit operator MyChild(DataBuilderChild dataBuilder)
        {
            return dataBuilder.Build();
        }
    }
