    static void ChangeArray(ref string[] arr)
    {
        // Since 'arr' is passed by reference, changing the value of 'arr'
        // changes the reference that the caller has.
        arr = (arr.Reverse()).ToArray();
        // The following statement displays Sat as the first element in the array.
        System.Console.WriteLine("arr[0] is {0} in ChangeArray.", arr[0]);
    }
