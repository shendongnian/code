    static void ChangeArray(ref string[] arr)
    {
        // The following attempt to reverse the array does not persist when 
        // the method returns, because arr is a value parameter.
        arr = (arr.Reverse()).ToArray();
        // The following statement displays Sat as the first element in the array.
        System.Console.WriteLine("arr[0] is {0} in ChangeArray.", arr[0]);
    }
