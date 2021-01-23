    string ab = "ab";  
    string anotherAB = "ab";  
    string another = 'a'.ToString() + 'b'.ToString();    
    Console.WriteLine(object.ReferenceEquals(ab, anotherAB)); // true
    Console.WriteLine(object.ReferenceEquals(ab, "ab")); // true
    Console.WriteLine(object.ReferenceEquals(ab, another)); // false
    Console.WriteLine(object.ReferenceEquals("ab", another)); // false
