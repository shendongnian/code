        [DefaultEvent( "SelectedIndexChanged" ), DefaultProperty( "Items" )]
        class Header : Control
        {
            ...
            [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
            public BindingList<HeaderItem> Items
            {
                get { return _items; }
                set { _items = value; }
            }
           ...
    }
