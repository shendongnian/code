      struct Person { 
        public string Name; 
        public int Age; 
      }
    
      // generic List<T> is much better than deprecated List
      List<Person> People = new List<Person>();
      ...
      People.Sort((x, y) => x.Age - y.Age);
