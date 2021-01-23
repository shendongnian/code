    class B
    {
       public string PropertyToSortBy { get; set; }
       // Provides the Null object
       public static B Empty
       {
           get
           {
               // Initialize other properties as required
               return new B() { .PropertyToSortBy = string.Empty };
           }
       }
    }
