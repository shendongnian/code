    public static class Versions
    {
        public static int Major { get { return Convert.ToInt32(MajorString); } }
        public static int Minor { get { return Convert.ToInt32(MinorString); } }
        public static int Build { get { return Convert.ToInt32(BuildNumber.Build); } }
        public static int Revision { get { return Convert.ToInt32(BuildNumber.Revision); } }
 
        public const string AssemblyVersion = MajorString + "." + MinorString + "." +
            BuildNumber.Build + ". " + BuildNumber.Revision;
        private const string MajorString = "1";
        private const string MinorString = "2";
    }
