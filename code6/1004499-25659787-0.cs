                foreach (var col in this.Columns)
                {
                    var checkBox = new MenuItem()
                    {
                        Header = col.Header
                    };
                    //binding
                    Binding myBinding = new Binding("Visibility");
                    myBinding.Mode = BindingMode.TwoWay;
                    myBinding.Converter = new IsCheckedToVisibilityConverter();
                    checkBox.DataContext = col;
                    checkBox.SetBinding(MenuItem.IsCheckedProperty, myBinding);
                    checkBox.Click += checkBox_Click;
                    checkBox.Checked += checkBox_Checked;
                    checkBox.Unchecked += checkBox_Unchecked;
                    checkBox.StaysOpenOnClick = true;
                    contextMenu.Items.Add(checkBox);
                    
                }
