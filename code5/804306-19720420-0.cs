            var d =
    @"ABC-pqr-cv3-xa
    LKJ-eqq-cb2-ya
    POI-qqq-aaa-1
    ABC-pqr-cv3-xb
    UIO-qqq-xa
    LKJ-eqq-cb2-za
    POI-qqq-aaa-2
    UIO-qqq-xb
    LKJ-eqq-cb2-yb
    POI-qqq-aaa-3";
            var lines = d.Split(new string[] { Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries);
            var grp = from line in lines
                      group line by line.Substring(0, line.Length - 1) into g
                      select g;
            int i = 1;
            foreach (var g in grp) {
                Console.WriteLine(i++);
                foreach (var s in g) {
                    Console.WriteLine("\t{0}", s);
                    }
                }
