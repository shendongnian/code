    public interface IMyThing //Typeless
    {
        Type TypeParam {get;}
        object Operation(object a);
        object Property {get;set;}
    }
    public interface IMyThing<T> //TypeD
    {
        T Operation(T a);
        T Property {get;set;}
    }
    public class MyThing<T> : IMyThing<T>, IMyThing
    {
        public T Operation(T a) { .. }
        public T Property {get;set;}
        Type IMyThing.TypeParam {get{return typeof(T);}}
        object IMyThing.Operation(object a){return this.Operation((T)a);}
        object IMyThing.Property {get{return this.Property;}set{this.Property=(T)value;}}
    }
