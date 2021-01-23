    int[] array ={ 8,9,12,11,7} // or your result from your split on string;
    List<int> array2 = new List<int> { 8,9,12,11,7 } // your model.GetAllItems;
    
    // Call Intersect extension method.
    var intersect = array.Intersect(array2);
    // Write intersection to screen.
    foreach (int value in intersect)
    {
        Console.WriteLine(value); // Output: 8,9,12,11,7 
    }
