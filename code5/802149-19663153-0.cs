    int n = 5;
    int sum = 0;
    
    for (int i = 1; i <= n; i++) // Sum variables starting from 1 going to n
    {
      int prod = 1;
      for (int k = 1; k <= i + 2; k++) // Prod variables starting from 1 going to i+2
      {
        int simple = 3 * k + 2; // calculate the simple formula
        prod = prod * simple; // multiply with the last result
      }
    
      sum = sum + prod; // sum up
    }
 
