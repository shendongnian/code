    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            RightSide.DataSource = GetMultiList("Right side", RootItem);
            RightSide.DataBind();
        }
        else
        {   
         // ***HERE I NEED TO MAKE THE CHECK.
            // So the code below should only run if the postback came from the topmenu***
            var sectionItem = GetAncestorOrDefault(CurrentItem);
            Sitecore.Data.Database context = Sitecore.Context.Database;
            Sitecore.Data.Items.Item homeItem = context.GetItem("/sitecore/content/home");
            List<Item> items = new List<Item>();
            Sitecore.Data.Fields.MultilistField multilistField = homeItem.Fields["Right Side"];
            foreach (string id in multilistField)
            {
                Sitecore.Data.Items.Item multiItem = Sitecore.Context.Database.Items.GetItem(id);
                if (multiItem.HasChildren)
                {
                    items.Add(multiItem);
                }
            }
            foreach (Item item in items)
            {
                if (item.Name.Equals(sectionItem.Name))
                {
                    hiddenAttr.Value = sectionItem.Name;
                    break;
                }
                else
                {
                    hiddenAttr.Value = String.Empty;
                }
            }
        }
    }
