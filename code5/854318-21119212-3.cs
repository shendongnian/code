       public abstract class AbstractCloneable : ICloneable
       {
          public object Clone()
          {
             return this.MemberwiseClone();
          }
       }
