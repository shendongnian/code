    public partial class _Default : Page 
    {
      [WebMethod]
      public static string GetDate()
      {
        return DateTime.Now.ToString();
      }
    }
