    CrlList.Dispatcher.BeginInvoke(DispatcherPriority.Normal,
        (TabControl tabControl) =>
        {
            foreach (DitaNestedContent content in root.Content)
            {
                TabItem aTab = new TabItem();
                if (content.Paths != null)
                {
                    PublicationsListUserControl crlTree =
                        new PublicationsListUserControl(content.Path, filename);
                    crlTree.MinWidth = 5;
                    aTab.Content = crlTree;
                }
                aTab.Header = content.Name;
                tabControl.Items.Add(aTab);
            }
        }), CrlList);
