    void Main()
    {
    	abc[] data = new[] { new abc(){i=1}, new abc(){i=2} };
    
    var t1 = data[0];
    var t2 = t1;
    // here is the difference 
    // t2 is still pointing to its old location
    // but i will point a new position.
    t2.i  = 5 ; //assigning the new value to i
    // but t2 still pointing to t1
    //all will be identical now.
    Console.WriteLine(t2);
    Console.WriteLine(t1); 
    Console.WriteLine(data[0]);
 
      // repeating like you.
      t2 = new abc() {i=444};
     //now you will see t2 is different form t1. because
     // now t2 pointing to a new object instead of t1.
     Console.WriteLine(t2);
    Console.WriteLine(t1);
 
    }
    
    public class abc{
        public int i ;
    }
