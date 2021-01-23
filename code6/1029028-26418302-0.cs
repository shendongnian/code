            public class Model<T>
            {
                public delegate void UpdatePrototype<S>(S mdl);
    
                private List<UpdatePrototype<Model<T>>> listeners = new List<UpdatePrototype<Model<T>>>();
                public void Bind(UpdatePrototype<Model<T>> handler)
                {
                    listeners.Add(handler);
                }
    
                public void Sync()
                {
                    foreach (UpdatePrototype<Model<T>> handler in listeners)
                    {
                        handler(this);
                    }
                }
    
                public virtual string Name
                {
                    get
                    {
                        return "Model";
                    }
                }
            }
    
            public class MyModel : Model<MyModel>
            {
                public override string Name
                {
                    get
                    {
                        return "MyModel";
                    }
                }
            }
    
            public class YourModel : Model<YourModel>
            {
                public override string Name
                {
                    get
                    {
                        return "YourModel";
                    }
                }
            }
    
            void main()
            {
                MyModel mdl = new MyModel();
                mdl.Bind(MyUpdate);
                mdl.Sync();
    
                YourModel your = new YourModel();
                your.Bind(YourUpdate);
                your.Sync();
            }
    
            void MyUpdate(Model<MyModel> mdl)
            {
                Console.WriteLine("MY MODEL HANDLER");
                Console.WriteLine(mdl.Name);
            }
    
            void YourUpdate(Model<YourModel> mdl)
            {
                Console.WriteLine("YOUR MODEL HANDLER");
                Console.WriteLine(mdl.Name);
            }
