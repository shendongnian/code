            Char[] A1 = { 'a', 'b', 'c', 'd', 'e', 'f', 'g' };
            int[] A2 = { 5, 1 };
            int k = A2.Length;
            int N = A1.Length;
            for (int i = 0; i < k; i++)
            {
                A1[A2[i]] = '\0'; // place null charcater here
            }
            
            Char[] copy = new char[N];
            
            for (int i = 0,j=0; i < N; i++) // place all values in sorted order
            {
                if (A1[i] != '\0')
                    copy[j++] = A1[i];
            }
            for (int i = (N-k); i < N;i++ )
            {
                copy[i] = '-';
            }
            Console.WriteLine(copy);
