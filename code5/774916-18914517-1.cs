        List<int[]> collection = new List<int[]>();
        private void AddValues(int a, int b, int c)
        {
            collection.Add(new[] { a, b, c });
            if (c < 10)
            {
                c++;
                AddValues(a, b, c);
            }
            if (b < 20)
            {
                b++;
                c = 0;
                AddValues(a, b, c);   
            }
            if (a < 10)
            {
                a++;
                b = 0;
                c = 0;
                AddValues(a, b, c);
            }
        }
