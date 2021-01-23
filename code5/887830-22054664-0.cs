    HitTestResult hitTestResult; // TODO either from callback or result
    var fe = hitTestResult.VisualHit as FrameworkElement;
    if(fe != null)
    {
        var listViewItem = fe.TemplatedParent as ListViewItem;
        if(listViewItem != null)
        {
            // TODO Do something with the ListViewItem
        }
    }
