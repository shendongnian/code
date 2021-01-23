    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web;
    using System.Web.UI;
    using System.Web.UI.WebControls;
    using System.Web.Services;
    using System.Collections;
    
    public partial class _Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
    
        }
    
    
       [WebMethod]
       public static Array GetAllCars()
       {
          ArrayList arrayList = new ArrayList();
          arrayList.Add(1);
          arrayList.Add(2);
          arrayList.Add(3);
          return arrayList.ToArray();
       }
    
    }
