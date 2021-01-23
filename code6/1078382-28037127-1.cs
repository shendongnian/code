            //String you want to check
            string names = "Smith Anna";
            //Split
            char[] splitters = { '-', '_', '.',' '};
            List<string> result = names.Split(splitters).ToList();
            //Sort the list
            result.Sort();
