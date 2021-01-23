            List<List<long>> testList = new List<List<long>>();
            int myCounter = 0;
            // Populate your list here.
            foreach (var listOfLong in testList)
            {
                if (listOfLong.Count > 0)
                {
                    // This looks like what you were asking about, but this IF statement is unnecessary, since all members of the list must be longs.
                    if (listOfLong[0].GetType() == typeof(long))
                    {
                        myCounter++;
                    }
                }
            }
            MessageBox.Show("count = " + myCounter.ToString());
