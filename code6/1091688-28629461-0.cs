     var Object1s = new List<Object1>() { Object1 };
     var Object2s = new List<Object2>() { Object2 };
     var object3s = Object1s
         .Join(Object2s, o1 => o1.Property1, o2 => o2.Property1,
             (o1, o2) => new
             {
                 Property1 = o1.Property1,
                 Property2 = o1.Property2,
                 Property3 = o2.Property3
             }
         ).First();
