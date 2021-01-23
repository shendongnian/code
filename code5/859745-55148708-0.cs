    using System.Collections;
    using System.Collections.Generic;
    public interface  IAny
    {
        void InvokeGetterEvent();
    }
     public class AnyValueTypeDuck<T, V> : IAny
        where V : AnyValueTypeDuck<T, V>
     {
        public static event System.Action<V> GetterEvent;
        public T Data;
        public void InvokeGetterEvent()
        {
            GetterEvent.Invoke((V)this);
        }
     }
    // Then create some concrete classes:
    // Example :
    public class LifeConcreteProperty : AnyValueTypeDuck<int, LifeConcreteProperty>
    {
    }
    public class ManaConcreteProperty : AnyValueTypeDuck<float, ManaConcreteProperty>
    {
    }
    // Now to finally use it :
    public class UserClass
    {
        List<IAny> allDuckTypes = new List<IAny>();
    
        public void GetDucketTypeClass(IAny anyDuckObject)
        {
            LifeConcreteProperty.GetterEvent += GetDucketType;
            ManaConcreteProperty.GetterEvent += GetDucketType;
            anyDuckObject.InvokeGetterEvent();
            // it will propagate to event and will invoke 
            // best suitable overload method (GetDucketType)
            LifeConcreteProperty.GetterEvent -= GetDucketType;
            ManaConcreteProperty.GetterEvent -= GetDucketType;
        }
        public void GetDucketType(LifeConcreteProperty originalClass)
        {
            // Your efforts go here
		    int value =  originalClass.Data;
        }
	    public void GetDucketType(ManaConcreteProperty originalClass)
        {
            // Your efforts go here
		    float value =  originalClass.Data;
        }
    }
