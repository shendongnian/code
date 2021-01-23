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
             //Nothing particular in the base class, but maybe usefull for childs.
             //Not abstract so childs may not implement this if they don't need to.
          }
    
       }
       public class ConcreteCloneable : AbstractCloneable
       {
           protected override HandleCloned(AbstractCloneable clone)
           {
               //Clone is of the current type.
               ConcreteCloneable obj = (ConcreteCloneable) clone;
               //Here you have a superficial copy of "this". You can do wathever 
               //specific task you need to do.
               //e.g.:
               obj.SomeReferencedPropertie = this.SomeReferencedPropertie.Clone();
           }
       }
