    public class MyClass<TStruct> 
          where TStruct : struct
    {
        public MyClass (List<object> NewObjects)
        {
            NewObjects.Add (JsonConvert.DeserializeObject<TStruct>(JsonString));
        }
    }
