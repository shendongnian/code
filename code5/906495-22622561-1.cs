    static List<List<int>> FindCombinations(int x)
    {
        var combinations = new List<List<int>>();
        var P = new int[10];
        var R = new int[10];
        combinations.Add(Enumerable.Repeat(1,x)); // first combination
        P[1] = x;
        R[1] = 1;
        int d = 1, b, sum;
         while (P[1] > 1)
         {
             sum = 0;
             if (P[d] == 1)
             {
                sum = sum + R[d];
                d = d - 1;
             }
             sum = sum + P[d];
             R[d] = R[d] - 1;
             b = P[d] - 1;
             if (R[d] > 0) d++;
             P[d] = b;
             R[d] = sum/b;
             b = sum%b;
             if (b != 0)
             {
                d++;
                P[d] = b;
                R[d] = 1;
             }
             List<int> temp = new List<int>();
             for (int i = 1; i <= d; i++)
                temp = temp.Concat(Enumerable.Repeat(P[i], R[i])).ToList();
                
             combinations.Add(temp);
        }
        return combinations;
    } 
