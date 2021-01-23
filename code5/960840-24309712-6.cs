           for (int i = 0; i < value.Count / 3; i++)
            {
                var a = value[i];
                if (a > totalElements / 3) break;
                for (int j = i + 1; j < value.Count / 2; j++)
                {
                    var b = value[j];
                    var remaining = target - (a + b);
                    var remainingIndex = value.BinarySearch(remaining) + 1;
                    //or value.IndexOf(remaining) + 1; 
                    //if it's sequential like here and it's faster than Search
                    for (int k = j + 1; k < remainingIndex; k++)
                    {
                        var c = value[k];
                        if (a + b + c <= target)
                        {
                            var newR = new[] { a, b, c };
                            result.Add(newR);
                        }
                    }
                }
            }
