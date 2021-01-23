    public static class CatDataHelper
    {
        public static CatData<T> MakeCatData<T>(this List<T> list)
        {
            return new CatData<T>(list);
        }
    }
    //...
    var myCatObject = cats.MakeCatData();
