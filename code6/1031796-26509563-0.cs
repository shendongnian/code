        public class DynamicDocTypeControl : System.Web.UI.WebControl *(check namespace  for typos)
        {
            override Render(...) {
                //add some conditional logic here for your dynamicness...
                writer.Write("<!DOCTYPE HTML>");
            }
        }
