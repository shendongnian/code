    public enum HHSDBUtilsTypes 
    {
        Sqllite,
        SQCE,
        Flatfile,
        Test
    }
    public static class HHSConsts
    {
        private const string implementation = HHSDBUtilsTypes.Sqllite; // you might read this from the config file
        public static IHHSDBUtils GetUtils()
        {
             IHHSDBUtils impl;
             switch(implementation)
             {
                case HHSDBUtilsTypes.Sqllite:
                   impl = new SQLiteHHSDBUtils();
                break;
                case HHSDBUtilsTypes.SQCE:
                   impl = new SQCEHHSDBUtils();
                break;
                case HHSDBUtilsTypes.Sqllite:
                   impl = new FlatfileHHSDBUtils();
                break;
                default:
                   impl = new TestHHSDBUtils();
                break;
             }
             return impl;
        }
    }
