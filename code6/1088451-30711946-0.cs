    public partial class CMS
    {
        public static string SomeKey
        {
            get { return (string) ResourceProvider.GetResource("some_key"); }
        }
        // ... and many more ...
    }
