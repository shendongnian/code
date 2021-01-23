    public abstract class MyAbstractBaseClass
    {
         String m_url;
         public MyAbstractClass(String url)
         {
             m_url = url;
         }
         
         public abstract String GetSiteData();
    }
    public class SiteAGetter : MyAbstractBaseClass
    {
         // ...
         public override String GetSiteData()
         {
         // ...
         }
    }
