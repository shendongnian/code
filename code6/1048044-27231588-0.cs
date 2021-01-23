    public class SubmitTextBox : TextBox
    {
        public SubmitTextBox()
            : base()
        {
            PreviewKeyDown += SubmitTextBox_PreviewKeyDown;
        }
        private void SubmitTextBox_PreviewKeyDown(object sender, System.Windows.Input.KeyEventArgs e)
        {
            if (e.Key == System.Windows.Input.Key.Enter)
            {
                if (this.SubmitCommand != null && this.SubmitCommand.CanExecute(this.Text))
                {
                    // Note this executes the command, and returns
                    // the current value of the textbox.
                    this.SubmitCommand.Execute(this.Text);
                }
            }
        }
        /// <summary>
        /// The command to execute when the text is submitted (Enter is pressed).
        /// </summary>
        public ICommand SubmitCommand
        {
            get { return (ICommand)GetValue(SubmitCommandProperty); }
            set { SetValue(SubmitCommandProperty, value); }
        }
        // Using a DependencyProperty as the backing store for SubmitCommand.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty SubmitCommandProperty =
            DependencyProperty.Register("SubmitCommand", typeof(ICommand), typeof(SubmitTextBox), new PropertyMetadata(null));
    }
