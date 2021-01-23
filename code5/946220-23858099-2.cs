    public static Guid Open = new Guid("7ae15a71-6514-4559-8ea6-06b9ddc7a59a");
            public static Guid Closed = new Guid("41f81283-57f9-4bda-a03c-f632bd4d1628");
            public static Guid Hold = new Guid("41bcc323-258f-4e58-95be-e995a78d2ca8");
            public enum Status1
            {
                 Open,
                 Close,
                Hold
            }
            public static Dictionary<Guid, Status1> Dic = new Dictionary<Guid, Status1>()
            {
                {Open , Status1.Open},
                {Closed , Status1.Close},
                {Hold , Status1.Hold}
            };  
