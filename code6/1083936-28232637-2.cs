    Dictionary<string, TextBox> _dicTextBoxes;
        private void vsematrici_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            int selectedIndex = vsematrici.SelectedIndex + 2;
            StackPanel[] v = new StackPanel[selectedIndex];
            for (int i = 0; i < selectedIndex; i++)
            {
                v[i] = new StackPanel();
                v[i].Name = "matrixpanel" + i;
                v[i].Orientation = Orientation.Horizontal;
                _dicTextBoxes = new Dictionary<string, TextBox>();
                for (int j = 0; j < selectedIndex; j++)
                {
                    TextBox txtBox = new TextBox();
                    txtBox = new TextBox();
                    txtBox.Name = "a" + (i + 1) + (j + 1);
                    txtBox.Text = "a" + (i + 1) + (j + 1);
                    v[i].Children.Add(txtBox);
                    Thickness m = txtBox.Margin;
                    m.Left = 1;
                    m.Bottom = 1;
                    txtBox.Margin = m;
                    InputScope scope = new InputScope();
                    InputScopeName name = new InputScopeName();
                    name.NameValue = InputScopeNameValue.TelephoneNumber;
                    scope.Names.Add(name);
                    txtBox.InputScope = scope;
                    _dicTextBoxes.Add(txtBox.Name, txtBox);
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
            if (_dicTextBoxes != null)
            {
                // a23 is the name of textbox, 'a' is prefixe, '2' is the 2nd stackpanel you have added
                // '3' is the 3rd textbox you have added in stackpanel
                if (_dicTextBoxes.ContainsKey("a23"))
                {
                    //Do your work here
                    Double sa11v = Convert.ToDouble(_dicTextBoxes["a23"].Text);
                }
            }
        }
