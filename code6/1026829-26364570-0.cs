        List<ModelItem> selectedModelItems = new List<ModelItem>();
        protected override void OnPreviewKeyDown(KeyEventArgs e)
        {
            if (e.Key == Key.Delete)
            {
                IEnumerable<ModelItem> activities = wd.Context.Items.GetValue<Selection>().SelectedObjects;
                foreach (ModelItem mi in activities)
                {
                    selectedModelItems.Add(mi);
                }
            }
            base.OnPreviewKeyDown(e);
        }
