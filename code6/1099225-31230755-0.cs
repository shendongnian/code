        void presenter_Unloaded(object sender, RoutedEventArgs e)
        {
            if (this.Parent != null && this.Parent is FrameworkElement)
            {
                if ((this.VisualParent as FrameworkElement).IsLoaded)
                {
                    Dispatcher.Invoke(
                        (Action)delegate()
                        {
                            TagTextBoxObject item = (TagTextBoxObject)(sender as InlineUIContainer).Tag;
                            if (newItems.ContainsKey(item.Id))
                            {
                                newItems.Remove(item.Id);
                            }
                            if (!deletedItems.ContainsKey(item.Id))
                            {
                                deletedItems.Add(item.Id, item.Text);
                            }
                        });
                }
            }
        }
