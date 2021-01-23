    var a1 = "1,2,12,13";
    var a2 = "2,12,13";
    
    var b1 = a1.Split(new[] { ',' }, StringSplitOptions.RemoveEmptyEntries)
                .Select(x => int.Parse(x.Trim()))
                .Contains(1); // gives true
    var b2 = a2.Split(new[] { ',' }, StringSplitOptions.RemoveEmptyEntries)
                .Select(x => int.Parse(x.Trim()))
                .Contains(1); // gives false
