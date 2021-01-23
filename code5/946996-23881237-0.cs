            txt = new TextBox();
            txt.Margin = new Thickness(10, 10, 0, 0);
            txt.Name = "DynamicLine" + i;
            RegisterName(txt.Name, txt);
            Grid.SetRow(txt, i);
            Grid.SetColumn(txt, 2);
            grid_typeFixture.Children.Add(txt);
