    public class TemplateController : Controller
       {
           public ActionResult GetThreeColomnTemplate(SettingViewModel model)
            {
              ...
              return View("ThreeColomn",model);
            }
            
                
           public ActionResult GetThreeColomnTemplateAsFile(SettingViewModel model)
             {
                SettingViewModel model = ...
            
                ViewEngineResult result = ViewEngines.Engines.FindView(this.ControllerContext, "ThreeColomn", "_Layout");
                       string htmlTextView = GetViewToString(this.ControllerContext, result, model);
            
                        byte[] toBytes = Encoding.Unicode.GetBytes(htmlTextView);
            
                        return File(toBytes, "application/file","template.html");
                 }
                    
                    
                private string GetViewToString(ControllerContext context, ViewEngineResult result, object model)
                    {
                        string viewResult = "";
                        var viewData = ViewData; 
                        viewData.Model = model;           
                        TempDataDictionary tempData = new TempDataDictionary();
                        StringBuilder sb = new StringBuilder();
                        using (StringWriter sw = new StringWriter(sb))
                        {
                            using (HtmlTextWriter output = new HtmlTextWriter(sw))
                            {
                                ViewContext viewContext = new ViewContext(context,
                                    result.View, viewData, tempData, output);
                                result.View.Render(viewContext, output);
                            }
                            viewResult = sb.ToString();
                        }
                        return viewResult;
                    }
              }
