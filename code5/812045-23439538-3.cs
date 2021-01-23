    public static class ModelHelper
    {
        public static T Data<T>( String key)  
        {
            var html = ((System.Web.Mvc.WebViewPage)WebPageContext.Current.Page).Html;
            var model = html.ViewData.Model;
            return (T)model.GetType().GetProperty(key).GetValue(model) ;
        }
    }
