      private void ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
                    {
                        var itemIndex = combobox.Text;
                        string name = (combobox.SelectedItem as ComboBoxItem).Name;
                        var obj = dock.FindName("Exp_Name");
                        if (obj == null)
                        {
                            Expander expander = new Expander();
                            expander.Header = name;
                            expander.Name = "Exp_Name";
                            dock.Children.Add(expander);
                            this.RegisterName(expander.Name, expander);
                        }
                        else
                        {
                            var element = obj as Expander;
                            element.Header = name;
                        }
                    }
        
    Hope this helps.
