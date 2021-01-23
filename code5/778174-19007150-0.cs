    [StructLayout(LayoutKind.Sequential, Pack = 1)]
        class Myobj
        {
            public Myobj() {
                 sub1 = new Subobj1();
                 sub2 = new Subobj2();
            }
    
            public Subobj1 sub1 { get; set; }
            public Subobj2 sub2 { get; set; }
        }
