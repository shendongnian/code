    // A<T> inherites from B; 
    // T is restricted as being Person (Person is a class or interface)
    class A<T>: B where T: Person {
      ...
    }
