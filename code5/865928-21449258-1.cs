        private void Slider_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            var sliderValue = (int) MySlider.Value;
            MyDataGrid.ItemsSource = students.Where(item =>item.Age<sliderValue);           
        }
