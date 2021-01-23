     public JsonResult AracTipiAra(JQDTParams param)
            {
                using (var db = new MBOSSEntities())
                {
                    var q = from x in db.VW_ARACMARKATIPI select x;
                    var nonfilteredcount = q.Count();
                    //filter 
                    //-------------------------------------------------------------------
                    foreach (var item in param.columns)
                    {
                        var filterText = item.search.value;
                        if (!String.IsNullOrEmpty(filterText))
                        {
                            filterText = filterText.ToLower();
                            switch (item.name)
                            {
                                case "MARKAADI":
                                    q = q.Where(
                           x =>
                               x.MARKAADI.ToLower().Contains(filterText)
    
                       );
                                    break;
                                case "TIPADI":
                                    q = q.Where(
                           x =>
                               x.TIPADI.ToLower().Contains(filterText)
    
                       );
                                    break;
                            }
                        }
                    }
                    //order
                    //-------------------------------------------------------------------
                    foreach (var item in param.order)
                    {
                        string orderingFunction = "MARKAADI";
                        switch (item.column)
                        {
                            case 1: orderingFunction = "MARKAADI";
                                break;
    
                            case 2: orderingFunction = "TIPADI";
                                break;
    
                        }
    
                        q = OrderClass.OrderBy<VW_ARACMARKATIPI>(q, orderingFunction, item.dir.GetStringValue());
                    }
    
                    //result
                    //-------------------------------------------------------------------
                    var filteredCount = q.Count();
                    q = q.Skip(param.start).Take(param.length);
                    var data = q.ToList()
                        .Select(r => new[] {
                            r.ARACMARKAPK.ToString(),
                            r.MARKAADI,
                            r.TIPADI,
                        }
    
                        );
                    return Json(new
                    {
                        draw = param.draw,
                        recordsTotal = nonfilteredcount,
                        recordsFiltered = filteredCount,
                        data = data
                    }, JsonRequestBehavior.AllowGet);
    
                }
    
            }
