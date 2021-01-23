    public abstract class DataBuilderParent
    {
        private MyParent myParent;
        protected void SetDataBuilder(MyParent myParent)
        {
            this.myParent = myParent;
        }
        public DataBuilderParent WithId(int id)
        {
            myParent.Id = id;
            return this;
        }
        public abstract DataBuilderParent WithDescription(string description);
        private MyChild BuildAsChild()
        {
            return myParent as MyChild;
        }
        private MyParent Build()
        {
            return myParent;
        }
        public static implicit operator MyChild(DataBuilderParent dataBuilder)
        {
            return dataBuilder.BuildAsChild();
        }
        public static implicit operator MyParent(DataBuilderParent dataBuilder)
        {
            return dataBuilder.Build();
        }
    }
