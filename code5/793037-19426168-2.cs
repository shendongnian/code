    [HttpPost]
        public ActionResult ProjectUpdate()
        {
         **string strProjectId=Request.Form["strProjectId"].ToString();**//Or use Request["strProjectId"].ToString();
          return View("Index");
        }
    
    @Html.DropDownList("**strProjectId**", (IEnumerable<SelectListItem>)ViewBag.Projects)
