    SPUserToken token = oWeb.AllUsers["[AdministratorLoginName]"].UserToken;
    using(SPSite site = new SPSite("http://mysite/",token))
      {
        using(SPWeb web = site.OpenWeb())
        {
        SPQuery query = new SPQuery();
        SPList list = web.Lists["mylist"];
        SPListItemCollection items = list.Items;
        for (int i = 0;i <list.ItemCount; i++)
        {
          Console.WriteLine(items[i].Name);
        }
        }
      }
