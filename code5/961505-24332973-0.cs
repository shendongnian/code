     var clientDetails = reslandentity.CLIENT.Where(m => m.SUBSCRIBER_ID == userid);
     List<SelectListItem> items = new List<SelectListItem>();
     foreach (var item in clientDetails)
     {
        var clientProjectsList =
              (from client in reslandentity.CLIENT
               join clientProj in reslandentity.CLIENT_PROJECT
               on client.ID equals clientProj.CLIENT_ID
               join project in reslandentity.PROJECT
               on clientProj.PROJ_ID equals project.ID
               where client.IS_DELETED == "N" && clientProj.IS_DELETED
                         == "N" && project.IS_DELETED
                         == "N" && client.ID == item.ID
               select project).FirstOrDefault();
                if (clientProjectsList != null)
                {
                    items.Add(new SelectListItem() { Text = clientProjectsList.NAME, Value = clientProjectsList.ID.ToString() });
                }
     }
     SelectList list=new SelectList(items,"Value","Text",model.PROJ_ID);
     ViewBag.ProjectsList = list;
