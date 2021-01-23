       1     List<int> myList = new List<int>
       2         {
       3             1,2,3,4,5,6,7 // equivalent to calling `Add` 7 times
       4         };
       5     Console.WriteLine(myList.Capacity); // prints 8 
       6     myList.TrimExcess();
       7     Console.WriteLine(myList.Capacity); // prints 8
