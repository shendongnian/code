    [HttpPost]
        public ActionResult ProjectUpdate()
        {
         **string strProjectId=Request.Form("strProjectId").ToString();**
          return View("Index");
        }
    
    @Html.DropDownList("**strProjectId**", (IEnumerable<SelectListItem>)ViewBag.Projects)
