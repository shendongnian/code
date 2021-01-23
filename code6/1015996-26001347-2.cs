    var txt = "50573953463435464438414B58413135";
    var split = 2;
    var q=  Enumerable.Range(0, txt.Length / split)
            .Select(i => string.Format("0x{0}", txt.Substring(i * split, split)))
            .Select (x => Convert.ToByte(x, 16)); // Add
    		q.Dump();
