        class Node
        {
            ...
            public override string ToString()
            {
                return "Node: " + Operator + " " + Id + " " 
                    + string.Join(",", Children.Select(x => string.Format("({0}, {1})", x.Sign, x.Id)));
            }
    }
