    public class GetDynamicKeyAllowedRenderings : GetAllowedRenderings
        {
            //string that ends in a GUID
            public const string DynamicKeyRegex = @"(.+){[\d\w]{8}\-([\d\w]{4}\-){3}[\d\w]{12}}";
    
            public new void Process(GetPlaceholderRenderingsArgs args)
            {
                Assert.IsNotNull(args, "args");
    
                // get the placeholder key
                string placeholderKey = args.PlaceholderKey;
                var regex = new Regex(DynamicKeyRegex);
                Match match = regex.Match(placeholderKey);
    
                // if the placeholder key text followed by a Guid
                if (match.Success && match.Groups.Count > 0)
                {
                    // Is a dynamic placeholder
                    placeholderKey = match.Groups[1].Value;
                }
                else
                {
                    return;
                }
    
                // Same as Sitecore.Pipelines.GetPlaceholderRenderings.GetAllowedRenderings from here but with fake placeholderKey
                // i.e. the placeholder without the Guid
                Item placeholderItem = null;
                if (ID.IsNullOrEmpty(args.DeviceId))
                {
                    placeholderItem = Client.Page.GetPlaceholderItem(placeholderKey, args.ContentDatabase,
                                                                     args.LayoutDefinition);
                }
                else
                {
                    using (new DeviceSwitcher(args.DeviceId, args.ContentDatabase))
                    {
                        placeholderItem = Client.Page.GetPlaceholderItem(placeholderKey, args.ContentDatabase,
                                                                         args.LayoutDefinition);
                    }
                }
    
                List<Item> collection = null;
                if (placeholderItem != null)
                {
                    bool allowedControlsSpecified;
                    args.HasPlaceholderSettings = true;
                    collection = this.GetRenderings(placeholderItem, out allowedControlsSpecified);
                    if (allowedControlsSpecified)
                    {
                        // Hide the Layout/Rendering tree to show the Allowed Renderings
                        args.Options.ShowTree = false;
                    }
                }
                if (collection != null)
                {
                    if (args.PlaceholderRenderings == null)
                    {
                        args.PlaceholderRenderings = new List<Item>();
                    }
                    args.PlaceholderRenderings.AddRange(collection);
                }
            }
        }
