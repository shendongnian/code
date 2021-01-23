    using System.Reflection;
    using System.ComponentModel;
    using System.Linq.Expressions;
    namespace MvcApplication7.Controllers
    {
        public class HomeController : Controller
        {
            //
            // GET: /Home/
    
            public ActionResult Index()
            {
                return View();
            }
    
        }
    
        public static class Helper {
    
            public static HtmlString CreateDropDown(this HtmlHelper helper, Type enumType)
            {
    
                SelectList list = ToSelectList(typeof(PostType));
                string  Markup =  @"<select>";
                foreach(var item in list){
                    string disable =  item.Value == "1" ?  "disabled" : "";  //eavluate by yourself set it to disabled or not by user role just set a dummy condition
                    Markup +=  Environment.NewLine + string.Format("<option value='{0}' {1}>{2}</option>",item.Value,disable,item.Text);
                }
                Markup += "</select>";
                
                return new HtmlString(Markup);
            }
    
            public static SelectList ToSelectList(Type enumType)
            {
                var items = new List<SelectListItem>();
                foreach (var item in Enum.GetValues(enumType))
                {
                    FieldInfo fi = enumType.GetField(item.ToString());
                    DescriptionAttribute[] attributes = (DescriptionAttribute[])fi.GetCustomAttributes(typeof(DescriptionAttribute), false);
                    var title = "";
                    if (attributes != null && attributes.Length > 0)
                    {
                        title = attributes[0].Description;
                    }
                    else
                    {
                        title = item.ToString();
                    }
    
                    var listItem = new SelectListItem
                    {
                        Value = ((int)item).ToString(),
                        Text = title,
                      
                    };
                    items.Add(listItem);
                }
                return new SelectList(items, "Value", "Text");
            }
        }
        public enum PostType
        {
            PostType1,
            PostType2,
            PostType3,
            PostType4,
            PostType5,
            PostType6
        }
    
       
    }
