    List<string> result=new List<string>(); // NOT LOCAL!!!
    List<string> RecPermute(string soFar, string rest) {
        if (rest == "") {
            //soFar.Dump();
            result.Add(soFar);
        } else {
            for(int i=0; i<rest.Length; i++) {
                string next = soFar + rest[i];
                string remaining = rest.Substring(0, i) + rest.Substring(i+1);
                RecPermute(next, remaining);
        }
        }
        return result;
    }
