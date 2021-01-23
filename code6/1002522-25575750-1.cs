    public class SpecialTextBox : RichTextBox
    {
        public SpecialTextBox()
        {
            Background = new SolidColorBrush(System.Windows.Media.Color.FromArgb(
                System.Drawing.Color.ForestGreen.A,
                System.Drawing.Color.ForestGreen.R,
                System.Drawing.Color.ForestGreen.G,
                System.Drawing.Color.ForestGreen.B));
            this.Loaded += new RoutedEventHandler(SpecialTextBox_Loaded);
        }
        void SpecialTextBox_Loaded(object sender, RoutedEventArgs e)
        {
            AppendText("Initial Text...");
        }
    }
