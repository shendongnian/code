        private void Pivot_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            switch (MainPivot.SelectedIndex)
            {
                case 0:
                    Select0();
                    break;
                case 1:
                    Select1();
                    break;
                default:
                    MessageBox.Show("Add another case and write it's new method, " + Environment.NewLine +
                        "Also bind the `Tap` event of another image to a new handler calling this newly created method.");
                    break;
            }
        }
        private void Icon1_Tap(object sender, GestureEventArgs e)
        {
            Select1();
        }
        private void Select0()
        {
            icon0.Opacity = 1.0;
            icon1.Opacity = 0.5;
            MainPivot.SelectedIndex = 0;
        }
        private void Select1()
        {
            icon1.Opacity = 1.0;
            icon0.Opacity = 0.5;
            MainPivot.SelectedIndex = 1;
        }
        private void icon0_Tap(object sender, System.Windows.Input.GestureEventArgs e)
        {
            Select0();
        }
        private void icon1_Tap(object sender, System.Windows.Input.GestureEventArgs e)
        {
            Select1();
        }
