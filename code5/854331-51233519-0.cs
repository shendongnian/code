    public abstract class AbstractCloneable : ICloneable
        {
            public int BaseValue { get; set; }
            protected AbstractCloneable()
            {
                BaseValue = 1;
            }
            protected AbstractCloneable(AbstractCloneable d)
            {
                BaseValue = d.BaseValue;
            }
            public object Clone()
            {
                var clone = ObjectSupport.CloneFromCopyConstructor(this);
                if(clone == null)throw new ApplicationException("Hey Dude, you didn't define a copy constructor");
                return clone;
            }
        }
        public class ConcreteCloneable : AbstractCloneable
        {
            public int DerivedValue { get; set; }
            public ConcreteCloneable()
            {
                DerivedValue = 2;
            }
            public ConcreteCloneable(ConcreteCloneable d)
                : base(d)
            {
                DerivedValue = d.DerivedValue;
            }
        }
        public class ObjectSupport
        {
            public static object CloneFromCopyConstructor(System.Object d)
            {
                if (d != null)
                {
                    Type t = d.GetType();
                    foreach (ConstructorInfo ci in t.GetConstructors())
                    {
                        ParameterInfo[] pi = ci.GetParameters();
                        if (pi.Length == 1 && pi[0].ParameterType == t)
                        {
                            return ci.Invoke(new object[] { d });
                        }
                    }
                }
                return null;
            }
        }
