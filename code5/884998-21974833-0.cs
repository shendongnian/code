    public ActionResult GetNames(string name)
    {
        ActionResult res = null;
        WcfWebProxy.Using(client =>
        {
            var names = client.GetAllNames().Select(f => new
            {
                Text = f.NewNames
            });
            res = Json(names.ToList(), JsonRequestBehavior.AllowGet);
        });
       return res;
    }
