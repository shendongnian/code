     private void CopyClicked(object sender, ExecutedRoutedEventArgs e)
        {
            var stringBuilder = new StringBuilder();
            IList l = this.DataGrid.SelectedItems;
            foreach (Data data in l)
            {
                stringBuilder.Append("\"" + data.Col1 +"\",");
                stringBuilder.Append("\"" + data.Col2 + "\",");
                stringBuilder.Append("\"" + data.Col3 + "\"");
                stringBuilder.AppendLine();
            }
            //Write to a file or straight to clipboard etc
            Debug.WriteLine(stringBuilder.ToString());
        }
