     Gtk.Application.Invoke (delegate {
             double d = new Random().NextDouble();
             for (int i = 0; i < 4; i++) {
                 ((Label)((MenuItem)menu.Children[i]).Child).Text = d.ToString();
             }
        });
