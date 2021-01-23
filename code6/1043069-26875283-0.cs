     private void Grid_Tap(object sender, System.Windows.Input.GestureEventArgs e)
        {
            int id = -1;
            var element = (FrameworkElement)sender;
            if (int.TryParse((Grid)element.Tag + "", out id)) {
            ... my code 
            }
        }
