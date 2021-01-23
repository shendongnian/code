    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web;
    using System.Web.UI;
    using System.Web.UI.WebControls;
    string json = "" +
                    "  [" +
                    "     \"Steve\"," +
                    "     \"was\"," +
                    "     \"here\"" +
                    "   ]" +
                    "";
    
    String[] data = new System.Web.Script.Serialization.JavaScriptSerializer().Deserialize<String[]>(json);
