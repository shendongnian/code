        private void Button1_Click(object sender, RoutedEventArgs e)
        {
                    Grid WholeGrid = new Grid();
                    WholeGrid.HorizontalAlignment = HorizontalAlignment.Left;
                    ColumnDefinition colDef1 = new ColumnDefinition();
                    ColumnDefinition colDef2 = new ColumnDefinition();
                    ColumnDefinition colDef3 = new ColumnDefinition();
                    WholeGrid.ColumnDefinitions.Add(colDef1);
                    WholeGrid.ColumnDefinitions.Add(colDef2);
                    WholeGrid.ColumnDefinitions.Add(colDef3);
                    // Create Question Lable
                    Label QuestionLabel = new Label();
                    QuestionLabel.Content = "Apple";
                    Grid.SetRow(QuestionLabel, 0);
                    Grid.SetColumn(QuestionLabel, 0);
                    // Create Date Picker
                    DatePicker newDatePicker = new DatePicker();
                    newDatePicker.Width = 200;
                    newDatePicker.Height = 20;
                    Grid.SetRow(newDatePicker, 0);
                    Grid.SetColumn(newDatePicker, 1);
                    // Add to Lable and Date Picker
                    WholeGrid.Children.Add(QuestionLabel);
                    WholeGrid.Children.Add(newDatePicker);
                    ListBox1.Items.Add(WholeGrid);
        }
