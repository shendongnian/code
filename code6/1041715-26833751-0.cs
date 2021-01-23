    // Adapted the following from http://www.codeease.com/only-remove-pushpins-from-a-layer-in-bing-map.html
    private void ClearPushpins()
    {
        List<UIElement> elementsToRemove = new List<UIElement>();
        List<UIElement> pushpinToRemove = new List<UIElement>();
        foreach (String photoset in App.CurrentlyMappedPhotosets)
        {
            foreach (UIElement element in photraxMap.Children)
            {
                if (element.GetType() == typeof(MapLayer))
                {
                    MapLayer Lay = (MapLayer)element;
                    if (Lay.Name == photoset)
                    {
                        foreach (UIElement p in Lay.Children)
                        {
                            if (p.GetType() == typeof(Pushpin))
                            {
                                pushpinToRemove.Add(p);
                            }
                        }
                        foreach (UIElement pin in pushpinToRemove)
                        {
                            Lay.Children.Remove(pin);
    
                        }
                        elementsToRemove.Add(Lay);
                    }
                }
                foreach (UIElement e in elementsToRemove)
                {
                    photraxMap.Children.Remove(e);
                }
            }
        }
    }
