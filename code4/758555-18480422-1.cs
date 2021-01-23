        private void Slider_PointerCaptureLost(object sender, DragCompletedEventArgs e)
        {
            Slider s = sender as Slider;
            // Your code
            MessageBox.Show(s.Value.ToString());
        }
