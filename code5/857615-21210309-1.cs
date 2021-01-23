    public class A
       {
       }
    
           MyMethod()
           {
               int myInt; // Initialized to zero, yes, but not yet assigned.
                          // An error to use this before assigning it.
    
               A myA;  // defaults to null, which may be a valid initial state, but still unassigned.
                       // Also an error to use this before assigning it.
    
               A oneMoreA = null; // Same value as default, but at least intention is clear.
               A anotherA = new A(); // What is or is not happening in the constructor is a separate issue.
                                     // At least anotherA  refers to an actual instance of the class.
