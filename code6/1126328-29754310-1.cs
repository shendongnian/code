    namespace <NAMESPACE_OF_MYCONTAINER_CLASS>
    {
        public partial class MyContainer
        {
            public double MyAction(Guid id)
            {
                Uri actionUri = new Uri(this.BaseUri,
                    String.Format("MyEntities(guid'{0}')/MyAction", id)
                    );
    
                return this.Execute<string>(actionUri, 
                    "POST", true).First();
            }
        }
    } 
