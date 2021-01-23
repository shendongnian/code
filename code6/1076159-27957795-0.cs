    // Namespaces you need
    using System.Linq;
    using System.Collections.Generic;
    ////////////////////////////////////////////
    // In your code block                     //
    ////////////////////////////////////////////
    List<T[]> myJaggedList = new List<T[]>();
    // (Populate here)
    
    T[] flatArray = myJaggedList.SelectMany(m => m).ToArray();
