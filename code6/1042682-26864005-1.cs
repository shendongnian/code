    private IEnumerable<SelectListItem> GetAllServers()
    {
    
    
    var serverList = from s in db.tbl_equipment
                         where (s.Company == "Contoso Ltd") && (s.Calc_Contract_Status == true)
                         where (s.Equip_type == "PC") || (s.Equip_type == "Laptop") || (s.Equip_type == "Mac") || (s.Equip_type == "Tablet") || (s.Equip_type.Contains("Server"))
                         select s;
    
        var servers = serverList 
                    .Select(x =>
                            new SelectListItem
                                {
                                    Value = x.serverId.ToString(), //assuming you have this two property           in your table
                                    Text = x.severName
                                });
    
        return new SelectList(servers , "Value", "Text");
    }
    
    public ActionResult GetServerList()
    {
        var model = new ServerViewModel
                        {
                            ServerList = GetAllServers()
                        };
        return View(model);
    }
