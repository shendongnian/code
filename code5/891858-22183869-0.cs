            List<String> outputStringList = new List<string>();
            IEnumerable<String> stringEnumerable = System.IO.File.ReadLines(@"c:\tmp\test.txt");
            System.Collections.Generic.HashSet<String> uniqueHashSet = new System.Collections.Generic.HashSet<String>();
            foreach (String line in stringEnumerable) { uniqueHashSet.Add(line); }
            foreach (String output in uniqueHashSet)
            {
                Int32 count = stringEnumerable.Count(element => element == output);
                if (count > 1) { outputStringList.Add(output + " " + count); }
                //if (count > 1) { System.Diagnostics.Debug.WriteLine(output + " " + count); }
            }
