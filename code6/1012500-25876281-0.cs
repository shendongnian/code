    public partial class MyPage : Page 
    {
        [WebMethod]
        public static string GetValue()
        {
            return "some value";
        }
    }
