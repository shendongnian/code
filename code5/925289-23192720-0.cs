    string s = Console.ReadLine();
    string[] arr = s.Split(' '); //Split the single string into multiple strings using space as delimiter
    int[] intarr = new int[arr.Length];
            
    for(int i=0;i<arr.Length;i++)
     {
      intarr[i] = int.Parse(arr[i]); //Parse the string as integers and fill the integer array
     }
            
    for(int i=0;i<arr.Length;i++)
     {
      Console.Write(intarr[i]);
     }
