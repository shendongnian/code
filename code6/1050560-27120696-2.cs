    public class Vector3D<T>
    {
        public T x; 
        public T y; 
        public T z;    
    }
    
    var vector = new Vector3D<int>() { x = 0, y = 0, z = 0 }; // I'm using the object initializer here.
