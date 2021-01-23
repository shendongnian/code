    public class DoesItemExist
    {
        Sitecore.Data.Database master = Sitecore.Configuration.Factory.GetDatabase("master");
        public void OnItemAdding(object sender, EventArgs args)
        {
            Item dbItem = master.GetItem("/sitecore/content/Administration/Development Settings/Lookups");
            Item selectedItem = Event.ExtractParameter(args, 0) as Item;
            foreach (Item item in dbItem.Axes.GetDescendants())
            {
                if (item.Template.Name.Contains("entry"))
                {
                    if (item.Fields["Key"].Value == selectedItem.Fields["Key"].Value)
                    {
                        SitecoreEventArgs evt = args as SitecoreEventArgs;
                        evt.Result.Cancel = true;
                        Sitecore.Context.ClientPage.ClientResponse.Alert("Item already exists");
                    }
                }
            }
        }
    }
