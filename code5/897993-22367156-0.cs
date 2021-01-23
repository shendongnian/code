    //Class Definition
    public class MyClass
    {
       //Data Member with inline initialization
       private int myInt = 1;
       
       //Standard property
       public int MyIntProp
       {
          get { return myInt; }
          set { myInt = value; }
       }
    
       //Auto-property, generates the same getter/setter as above with a "hidden" backing property.
       public String MyStringProp {get; set;}
    
       //Class constructor, great for initialization!
       public MyClass()
       {
           //Set the property to an initial value
           MyStringProp = "Hello World";
       }
    }
