    public class ItemConverter : JavaScriptConverter
    {
        public override IEnumerable<Type> SupportedTypes
        {
            get { return new List<Type>() { typeof(IItem) }; }
        }
    
        public override IDictionary<string, object> Serialize(object obj, JavaScriptSerializer serializer)
        {
            throw new NotImplementedException();
        }
    
        public override object Deserialize(IDictionary<string, object> dictionary, Type type, JavaScriptSerializer serializer)
        {
            //If we are of type IItem
            if (dictionary.ContainsKey("Type")) //My check to make sure we are of type IItem
            {
                var factory = new ItemFactory();
                return factory.CreateItem((int)dictionary["Id"], (string)dictionary["Options"], (ItemTypes)dictionary["Type"]);
            }
            else
            {
                return null;
            }
        }
    }
    [WebService(Namespace = "http://tempuri.org/")] 
    [ScriptService]
    public class MyService : System.Web.Services.WebService {
    
        public MyService () { }
    
        [WebMethod(EnableSession = true)]
        [ScriptMethod]
        public void SaveThing(string myThing) 
        {
            //Get our custom converter
            var itemConverter = new ItemConverter();
            var serialiser = new JavaScriptSerializer();
            //Register it
            serialiser.RegisterConverters(new List<JavaScriptConverter>() { itemConverter });
            //Deserialise the dashboard
            var theThing = serialiser.Deserialize<Thing>(myThing);
            //Save
            theThing.Save();
        }
    }
