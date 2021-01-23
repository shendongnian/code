    var variable = Method(
        delegate(IList<string> i, IList<string> j) {
        //                        ^
            return new Test() {
                Implisity = i[j.IndexOf("Implisity")]
             };
        }
    );
