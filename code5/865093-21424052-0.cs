    using System.Web;
    
    List<MyEntity> list = (List<MyEntity>)HttpContext.Current.Session["MySession"];
    
    if (list != null)
    {
        foreach (MyEntity item in list)
        {
            Response.Write(item.ToString());  // <-- you may want to override ToString to display the content
        }
    }
