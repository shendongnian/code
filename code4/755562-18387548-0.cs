     List<String> permutations(String original, int numberOfWildcards) {
            //add 1 more wildcard to each posible position in the original string
            List<String> perm = new List<String>();
            for (int i = 0; i < original.Length; ++i)
            {
                if (original[i] != '_')
                    perm.Add(original.Substring(0, i) + "_" + original.Substring(i + 1, original.Length));
            }
            if ( numberOfWildcards == 1)
            {
                  return perm;
            }
            //now if we need to search deeper we recusively do this for each substring
            List<String> permWithMoreWildmark = new List<String>();
            foreach (var str in perm)
            {
                permWithMoreWildmark.AddRange(permutations(str,numberOfWildcards-1));
            }
            return permWithMoreWildmark;
        } 
