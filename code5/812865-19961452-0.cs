    public void OnItemSaved(Object sender, EventArgs args)
        {
            var item = Event.ExtractParameter(args, 0) as Item;
    
            using (new SecurityDisabler())
            {
                if (item != null)
                {
                    if (item.Paths.IsMediaItem)
                    {
                        var source = Factory.GetDatabase("master");;
                        var target = Factory.GetDatabase("web");;
    
                        var options = new PublishOptions(source, target, PublishMode.SingleItem, item.Language, DateTime.Now)
                                          {
                                              RootItem = item,
                                              Deep = true,
                                          };
    
                        var publisher = new Publisher(options);
    
                        publisher.PublishAsync();
                    }
                }
            }
        }
