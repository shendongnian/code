    public class ModelTest : IPersistent
        {
            private int? _id;
            public object Id
            {
                get { return this._id; }
                set { this._id = new Nullable<int>((int)(long)value); }
            }
            public string Name { get; set; }
        }
