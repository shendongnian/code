     public class GenericClass<T>
     {
        T X { get; set; }
        T Y { get; set; }
        T Z { get; set; }
     }
     GenericClass<float> floatClass = new GenericClass<float>();
     GenericClass<double> doubleClass = new GenericClass<double>();
