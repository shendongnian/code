    public enum PageTypeEnum{ ListPage,WebviewPage};
    public abstract class BasePage 
    {
      //Common data..
      public abstract PagetTypeEnum PageType{get;}
    } 
    public class ListPage : BasePage
    {
       public overide PageTypeENum PageType {get{return PageTypeEnum.ListPage;}}
    }
    public class WebviewPage: BasePage
    {
       public overide PageTypeENum PageType {get{return PageTypeEnum.WebviewPage;}}
    }   
