         int[] A = { 2, 3, 4, 3, 4, 2, 4, 2, 4 };
         List<int> B = new List<int>(); // <= We need this to check already counted numbers in array
         int temp = 0; // <= A temporary variable to get a count per a specific elemet
         int count = 0; // < = Will hold number of elements we have already counted 
         Console.WriteLine("A|B");
         for (int i = 0; i < A.Length; i++)
         {
             temp = 0;
             // Check for a fresh number 
             if (!B.Contains(A[i]))
             {
                 B.Add(A[i]);
                 // For each element we try to count the number of occurrence 
                 for (int j = 0; j < A.Length; j++)
                 {
                     // Current element i matched with a element in array; counts increased 
                     if (A[i] == A[j])
                     {
                            temp++; // < = Local count
                            count++; // <= Kind of the global count of elements we have passed
                     }
                 }
                    Console.WriteLine(A[i] + "|" + temp); 
                }
               // We need to do this only for unique elements; when we have counted all elements in Array A we are done
               if (count >= A.Length)
               {
                    break;
               }
          }
