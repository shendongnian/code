    private void List_OnSizeChanged(object sender, SizeChangedEventArgs e)
    {
            var list = sender as ListViewBase;   // works with ListView or GridView
            if (list == null || list.Items == null)
            {
                return;
            }
            
            var nMax = 6; // set this to your desired number of items
            var n = list.Items.Count;
            var gen = list.ItemContainerGenerator;
            if (gen != null)
            {
                var height = 0.0;
                DependencyObject o;
                for (var i = 0;
                     i < nMax
                     && i < n
                     && (o = gen.ContainerFromIndex(i)) != null;
                     i++)
                {
                    // calculate running height
                    var h = o.GetValue(ActualHeightProperty) as double? ?? 0;
                    height += h+2;
                }
                // set height, unsub and resub to listeners otherwise endless layout cycle
                if (height > 0)
                {
                    list.SizeChanged -= List_OnSizeChanged;
                    list.Height = height;
                    list.SizeChanged += List_OnSizeChanged;
                }
            }
        }
