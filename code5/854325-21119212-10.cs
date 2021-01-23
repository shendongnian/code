       public abstract class AbstractCloneable : ICloneable
       {
          public object Clone()
          {
             var clone = (AbstractCloneable) this.MemberwiseClone();
             HandleCloned(clone);
             return clone;
          }
    
          protected virtual HandleCloned(AbstractCloneable clone)
          {
             //Nothing particular in the base class, but maybe useful for children.
             //Not abstract so children may not implement this if they don't need to.
          }
       }
       public class ConcreteCloneable : AbstractCloneable
       {
           protected override HandleCloned(AbstractCloneable clone)
           {
               //Get whathever magic a base class could have implemented.
               base.HandleCloned(clone);
               //Clone is of the current type.
               ConcreteCloneable obj = (ConcreteCloneable) clone;
               //Here you have a superficial copy of "this". You can do whathever 
               //specific task you need to do.
               //e.g.:
               obj.SomeReferencedProperty = this.SomeReferencedProperty.Clone();
           }
       }
