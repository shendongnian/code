    public partial class PCDataEFContext : DbContext
    {
        public PCDataEFContext()
            : base(Util.GetTheConnectionString())
        {
        }
    }
    class Util
    {
        public static string GetTheConnectionString()
        {
            // return the correct name based on some logic...
            return "name=PCDataEFContext";
        }
    }
