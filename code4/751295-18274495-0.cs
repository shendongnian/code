    class Part {
        IEnumerable<Part> SubParts {get;set;}
        public int TotalParts {
            get {
                return 1 + SubParts.Sum(p => p.TotalParts);
                //     ^                       ^
                //     |                       |
                // Add one for this part       |
                //                             |
                //         Use LINQ to aggregate counts recursively
            }
        }
    }
