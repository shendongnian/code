        private static void ItemsSourceChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            ItemsHub hub = d as ItemsHub;
            if (hub != null)
            {
                IList items = e.NewValue as IList;
                if (items != null)
                {
                    var spotLightSection = hub.SpotlightSection;
                    hub.Sections.Clear();
                    if (spotLightSection != null)
                    {
                        hub.Sections.Add(spotLightSection);
                    }
                    foreach (var item in items)
                    {
                        HubSection section = new HubSection();
                        DataTemplate headerTemplate = hub.SectionHeaderTemplate;
                        section.HeaderTemplate = headerTemplate;
                        DataTemplate contentTemplate = hub.ItemTemplate;
                        section.ContentTemplate = contentTemplate;
                        section.DataContext = item;
                        section.Header = item;
                        
                        //This line fixed my problem.
                        section.IsHeaderInteractive = true;
                        hub.Sections.Add(section);
                    }
                }
            }
