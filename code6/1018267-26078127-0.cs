    string args = "(x,y)(x,y)(x,y)(x,y)";
    return Regex.Matches("(4,1)(7,5)(5,4)(2,3)", @"\(([^)]*)\)")
                .Cast<Match>()
                .Select(c => 
                       {
                           var ret = c.Groups[1].Value.Split(',');
                           return new Point(int.Parse(ret[0]), int.Parse(ret[1]));
                       }))
