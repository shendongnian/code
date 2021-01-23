        class Node
        {
            public int Id { get; set; }
            public int? ParentId { get; set; }
            public string Operator { get; set; }
            public Node Parent { get; set; }
            public IList<Node> Children { get; set; }
            // HERE WE GO
            public int Sign { get; set; }
            ...
        }
