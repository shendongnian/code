     private static bool AreListsEqual(List<int> list1, List<int> list2)
     {
            var areListsEqual = true;
            if (list1.Count != list2.Count)
                return false;
            for (var i = 0; i < list1.Count; i++)
            {
                if (list2[i] != list1[i])
                {
                    areListsEqual = false;
                }
            }
            return areListsEqual;
     }
