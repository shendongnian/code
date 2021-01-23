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
                AddValues(a, b, c);   
            }
            if (a < 10)
            {
                a++;
                AddValues(a, b, c);
            }
        }
