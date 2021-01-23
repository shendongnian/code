     private void StepsList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            _viewModel.SetStep(StepsList.SelectedIndex);
            var gridView = StepsList.View as GridView;
            var listBoxItem = StepsList.ItemContainerGenerator.ContainerFromItem(StepsList.SelectedItem) as ListBoxItem;
            var listBoxItems = Enumerable.Range(0, StepsList.Items.Count).Select(x => StepsList.ItemContainerGenerator.ContainerFromIndex(x) as ListBoxItem);
            var column = gridView.Columns[0];
            Button up;
            Button down;
            foreach (var contentPresenter in listBoxItems.Where(x => x != null).Select(x => x.GetVisualChild<ContentPresenter>()))
            {
                up = column.CellTemplate.FindName("StepUp", contentPresenter) as Button;
                down = column.CellTemplate.FindName("StepDown", contentPresenter) as Button;
                up.Visibility = Visibility.Hidden;
                down.Visibility = Visibility.Hidden;
                up.IsEnabled = true;
                down.IsEnabled = true;
            }
            if (listBoxItem == null) return;
            var myContentPresenter = listBoxItem.GetVisualChild<ContentPresenter>();
            up = column.CellTemplate.FindName("StepUp", myContentPresenter) as Button;
            down = column.CellTemplate.FindName("StepDown", myContentPresenter) as Button;
            if (up == null) return;
            up.Visibility = Visibility.Visible;
            if (Equals(_viewModel.Steps.First(), StepsList.SelectedItem))
                up.IsEnabled = false;
            if (down == null) return;
            down.Visibility = Visibility.Visible;
            if (Equals(_viewModel.Steps.Last(), StepsList.SelectedItem))
                down.IsEnabled = false;
        }
