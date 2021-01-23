    public sealed class NoteStyleSelector : StyleSelector
    {
        public override Style SelectStyle(object item, DependencyObject container)
        {
            FrameworkElement fe = container as FrameworkElement;
            if (fe!= null)
            {
                if (item is Note)
                { return (Style)fe.FindResource("NoteStyle"); }
                if (item is NoteFolder)
                { return (Style)fe.FindResource("NoteFolderStyle"); }
            }
            return base.SelectStyle(item, container);
        }
    }
