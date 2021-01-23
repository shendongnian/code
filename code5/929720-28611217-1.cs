    public class ChangeColumnGridView : System.Web.UI.WebControls.GridView
    {
      protected override ICollection CreateColumns(PagedDataSource dataSource, bool useDataSource)
      {
        // Get the needful from the base class
        var baseColList = base.CreateColumns(dataSource, useDataSource);
        var inColList = baseColList.OfType<object>();
    
        // Get our column order 
        string columnOrder;
    
        if (Page.Request.Cookies["colOrder"] != null)
          columnOrder = Page.Request.Cookies["colOrder"].Value;
        else
          return baseColList;
          
        // change it to an array
        string[] columnOrderA = columnOrder.Split(new char[] { '|' });
    
        // this is where we will put our results
        ArrayList newColumnList = new ArrayList();
    
        // look for each name in the list and add when we find it.
        foreach (string name in columnOrderA)
        {
          var found = inColList.Where((c) => c.ToString() == name).FirstOrDefault();
    
          if (found != null)
            newColumnList.Add(found);
        }
    
        // look for non-visible items in the list and add them if we don't already have them.
        foreach (var a in inColList)
        {
          if (((System.Web.UI.WebControls.DataControlField)a).Visible == false)
          {
            var found = newColumnList.Cast<object>().Where((c) => c.ToString() == a.ToString()).FirstOrDefault();
            if (found == null)
              newColumnList.Add(a);
          }
        }
    
        return newColumnList;
      }
    }
