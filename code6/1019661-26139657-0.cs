    public class StringKeyValueIncrementalCollection : ObservableCollection<StringKeyValue>, ISupportIncrementalLoading
        {
    
            private List<StringKeyValue> allCategories;
            private int lastItem = 1;
    
            public StringKeyValueIncrementalCollection(List<StringKeyValue> categories)
            {
                this.allCategories = categories;
            }
    
            public bool HasMoreItems
            {
                get
                {
                    if (lastItem == allCategories.Count)
                    {
                        return false;
                    }
                    else
                    {
                        return true;
                    }
                }
            }
    
            public IAsyncOperation<LoadMoreItemsResult> LoadMoreItemsAsync(uint count)
            {
    
                CoreDispatcher coreDispatcher = Window.Current.Dispatcher;
    
                return Task.Run<LoadMoreItemsResult>(async () =>
                {
    
                    List<StringKeyValue> items = new List<StringKeyValue>();
                    for (int i = 0; i < count; i++)
                    {
                        items.Add(allCategories[i]);
                        lastItem++;
                        Debug.WriteLine(lastItem);
                        if (lastItem == allCategories.Count)
                        {
                            break;
                        }
                    }
    
                    await coreDispatcher.RunAsync(CoreDispatcherPriority.Normal,
                        () =>
                        {
                            foreach (StringKeyValue item in items)
                            {
                                this.Add(item);
                            }
                        });
    
                    return new LoadMoreItemsResult() { Count = count };
                }).AsAsyncOperation<LoadMoreItemsResult>();
            }
        }
