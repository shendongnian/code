    var numbers = new [] { 2, 1, 2, 1, 5, 6, 5 };
    var indices = numbers.IndicesOfAllElementsEqualTo(5); // Use extension method.
    // Make indices into an array if you want, like so
    // (not really necessary for this sample code):
    var indexArray = indices.ToArray();
    // This prints "4, 6":
    Console.WriteLine(string.Join(", ", indexArray));
