    namespace com.mystuff
    {
     public class MyPage: System.Web.UI.Page
     {
        public MyBasePage()
         {
             this.AsyncMode = true;
         }
     }
    }
    <system.web>
       <pages pageBaseType="com.mystuff.MyPage" />
    </system.web>
