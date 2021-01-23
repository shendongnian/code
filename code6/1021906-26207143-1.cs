            /// <summary>
            /// Invoked when this page is about to be displayed in a Frame.
            /// </summary>
            /// <param name="e">Event data that describes how this page was reached.  The Parameter
            /// property is typically used to configure the page.</param>
            protected override async void OnNavigatedTo(NavigationEventArgs e)
            {
                Bing.Maps.MapTileLayer layer = new Bing.Maps.MapTileLayer();
                layer.GetTileUri += layer_GetTileUri;
                this.map.TileLayers.Add(layer);
            }
     
            private async void layer_GetTileUri(object sender, Bing.Maps.GetTileUriEventArgs e)
            {
                e.Uri = this.ComposeMyCustomUri(e);
            }
