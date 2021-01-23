    public class ObjectA
    {
       public ObjectA() { } // Normal constructor
       public ObjectA(ObjectA objToCopy) { /* copy fields into new object */ }
    }
    
    MyField = anotherObjectA.Select(obja => new ObjectA(obja)).ToList();
