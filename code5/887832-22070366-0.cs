    for (int i = 0; i <= Verknüpfung.Count - 1; i += 2)
                {
                    Image Icon = new Image();
                    Icon.Source = new BitmapImage(new Uri(@"Images\Fugue Icons\document.png", UriKind.Relative));
                    Icon.Height = 16;
                    Icon.Width = 16;
                    Icon.Stretch = Stretch.None;
                    var tmp = i;
                    MenuItem MenuItem = new MenuItem();
                    MenuItem.Click += delegate { Process.Start(Verknüpfung[1 + tmp]); };
                    MenuItem.Header = Verknüpfung[0 + i];
                    MenuItem.Icon = Icon;
                    MenuItem.Padding = new Thickness(5);
                    MI_Verknüpfungen.Items.Add(MenuItem);
                }
