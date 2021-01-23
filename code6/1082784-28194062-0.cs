    public class NfceContext : DbContext{
      static NfceContext context;
     
      public static NfceContext() {
         context = new NfceContext();
      }
      public void ChangeDB(string appConfigConStr) {
          context = new NfceContext(appConfigConStr);
      }
    }
