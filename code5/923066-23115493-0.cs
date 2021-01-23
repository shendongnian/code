     public class EvilClass
     {
         public int SomeProperty { get; set; }
         public static explicit operator SomeOtherType(B bObj)
         {
             obj.SomeProperty = -1;
             return SomeOtherType.CreateFromEvilClass(bObj);
         }
     }
