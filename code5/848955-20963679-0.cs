    // Creates a IEnumerable<T> of the type of obj with 1 element and converts it to a List
    var xyz = Enumerable.Repeat(obj, 1).ToList();
    // Select takes each element in the List xyz 
    // and passes it to the lambda as the parameter xyzobj.
    // Each element is used to create a new res object with object initialization.
    // The res object has two properties, foo and xyzs.  foo is given the value bar 
    // (which was defined elsewhere).
    // The xyzs property is created using the element from xyz passed into the lambda
    var abc =  xyz.Select(
       xyzobj => new res {
            foo = bar,
            xyzs = new [] {xyzobj},
        }).ToList();
