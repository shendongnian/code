     TimsheetModel model=new TimesheetModel();
     if(btn=="Add Record")
     {
          var data= Session["ddlData"] as IEnumerable<SelectListItem>;
          SelectList list1=new SelectList(data,"Value","Text",model.ProjID);
          ViewBag.ProjectList=list1;
          model.Count++; // ADDS NEW RECORD
          return View(model);
     }
