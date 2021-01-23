    // Total numbers of instances that have been created
        public static int NumMembers { get; protected set; }
    
        // Static constructor initializes NumMembers
        static Member()
        {
            NumMembers = 0;
        }
    
        public Member()
        {
            // Increment member count and assign member number.
            NumMembers++;
        }
        public Member(string img, int mbrnum, string mbrname, string phonenum, string mbradd, List<string> rtls)
    :this()
        {
            MemberNumber = NumMembers;
            Img = img;
            MemberName = mbrname;
            MemberPhone = phonenum;
            MemberAddress = mbradd;
            Rentals = rtls;
        } // Working ctor
`
