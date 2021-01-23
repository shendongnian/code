            for (int iOneWordTitle = 0; iOneWordTitle < titles.Count(); iOneWordTitle++)
            {
                if (titles[iOneWordTitle].Equals(sSearch))
                {
                    Console.WriteLine(sSearch + " was found at position " + iOneWordTitle);
                    found = true;
                }
            }
