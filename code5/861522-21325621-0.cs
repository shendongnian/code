    private void button1_Click(object sender, RoutedEventArgs e)
            {
                TextBox dynamicTextBox = new TextBox();
                dynamicTextBox.Text = "Type Partnumber";
                Grid.SetRow(dynamicTextBox, 1);
                Grid.SetColumn(dynamicTextBox, 0);
                this.MainGrid.Children.Add(dynamicTextBox);
            }
