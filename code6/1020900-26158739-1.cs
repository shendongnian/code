         Dictionary<int, object> g = new Dictionary<int, object>() { { 1, new { j = "g" } }, { 2, new { j = "ggfdf" } }, { 3, new { j = "gioret" } } };
          
      gridviewparent.DataSource= g.Select(h => new {key= h.Key});
      gridviewparent.DataBind();
      foreach (GridViewRow item in gridviewparent.Rows)
            {
             int key= Convert.Toint32( ((Label)item.FindControl("lblkey")).Text) ;
                   GridView gridviewChild=(GridView)item.FindControl("gridviewchild");
                // return g[key]  in list
                gridviewChild.DataSource= g[key];
                gridviewChild.DataBind();
            } 
