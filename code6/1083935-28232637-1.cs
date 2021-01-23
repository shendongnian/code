        TextBox[] _t = null;
        private void vsematrici_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            int selectedIndex = vsematrici.SelectedIndex + 2;
            StackPanel[] v = new StackPanel[selectedIndex];
            for (int i = 0; i < selectedIndex; i++)
            {
                v[i] = new StackPanel();
                v[i].Name = "matrixpanel" + i;
                v[i].Orientation = Orientation.Horizontal;
                _t = new TextBox[selectedIndex];
                for (int j = 0; j < selectedIndex; j++)
                {
                    _t[j] = new TextBox();
                    _t[j].Name = "a" + (i + 1) + (j + 1);
                    _t[j].Text = "a" + (i + 1) + (j + 1);
                    v[i].Children.Add(_t[j]);
                    Thickness m = t[j].Margin;
                    m.Left = 1;
                    m.Bottom = 1;
                    _t[j].Margin = m;
                    InputScope scope = new InputScope();
                    InputScopeName name = new InputScopeName();
                    name.NameValue = InputScopeNameValue.TelephoneNumber;
                    scope.Names.Add(name);
                    _t[j].InputScope = scope;
                }
                mainpanel.Children.Add(v[i]);
            }
            Button button1 = new Button();
            button1.Content = "Найти определитель";
            button1.Click += Button_Click;
            mainpanel.Children.Add(button1);
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (_t != null)
            {
                //Do your work here
                // Double sa11v = Convert.ToDouble(t[j].Text);
            }
        }
