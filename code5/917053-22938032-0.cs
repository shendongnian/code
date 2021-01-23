        private void Import_Click(object sender, RoutedEventArgs e)
        {
            MessageBoxResult headerChoice = MessageBox.Show("Is the first row a column header?", "Import Options", MessageBoxButton.YesNo);
            string[][] array = fs.CSVToStringArray();
            for (int i = 0; i < array[0].Length; i++)
            {
                var col = new DataGridTextColumn();
                if (headerChoice == MessageBoxResult.Yes)
                    col.Header = array[0][i];
                else if (headerChoice == MessageBoxResult.No)
                    col.Header = "Column " + i;
                col.Binding = new Binding(string.Format("[{0}]", i));
                this.ExternalData._dataGrid.Columns.Add(col);
            }
            if (headerChoice == MessageBoxResult.Yes)
            {
                string[][] arrayNoHeader = new string[array.Length - 1][];
                for (int i = 0; i < arrayNoHeader.Length; i++)
                    arrayNoHeader[i] = array[i + 1];
                this.ExternalData._dataGrid.ItemsSource = arrayNoHeader;
            }
            else if (headerChoice == MessageBoxResult.No)
                this.ExternalData._dataGrid.ItemsSource = array;
        }
