    var myArray = new int[10];
    //Won't work because Array.Count is implemented with explicit interface implementation
    //where the interface is ICollection
    Console.Write(myArray.Count);
    //Will work because we've casted the Array to an ICollection
    Console.Write(((ICollection)myArray).Count);
