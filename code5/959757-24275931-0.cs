    public class MyDataClass : IDeserializationCallback
    {
       public int SimpleKeyProperty { get; set; }
       public string TextProperty{ get; set; }
       public void OnDeserialization(object sender)
       {
          //upon deserialization use the int key to get the latest value from
          //factory (this is make believe...)
          TextProperty = SomeFactory.GetCurrentValue( this.SimpleKeyProperty) ;
       }
    }
