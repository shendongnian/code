       string delimeter = ",";
            List<string> str = new List<string>();
            str.Add("a");
            str.Add("b");
            str.Add("c");
            str.Add("d");
           
            string result= String.Join(delimeter, str.ToArray());
