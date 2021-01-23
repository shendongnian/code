    [HttpPost]
            public ActionResult ProjectUpdate(FormCollection collection)
            {
             **string strProjectId=collection["strProjectId"].ToString();**
              return View("Index");
            }
        
        @Html.DropDownList("**strProjectId**", (IEnumerable<SelectListItem>)ViewBag.Projects)
