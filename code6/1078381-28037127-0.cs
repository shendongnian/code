            //String you want to check
            string names = "Smith Anna";
            //Perform replace (this probably should be regex instead)
            names = names.Replace("-", ",");
            names = names.Replace("_", ",");
            names = names.Replace(".", ",");
            names = names.Replace(" ", ",");
            //Split by comma
            List<string> result = names.Split(',').ToList();
            //Sort the list
            result.Sort();
