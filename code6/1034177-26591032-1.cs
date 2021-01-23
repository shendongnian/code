    public class PressAndReleaseButton : Button
    {
        public static readonly DependencyProperty PressCommandProperty = DependencyProperty.Register(
            "PressCommand", typeof(ICommand), typeof(PressAndReleaseButton), new PropertyMetadata(null));
        /// <summary>
        /// The Press command to bind
        /// </summary>
        public ICommand PressCommand
        {
            get { return (ICommand)GetValue(PressCommandProperty); }
            set { SetValue(PressCommandProperty, value); }
        }
        public static readonly DependencyProperty ReleaseCommandProperty = DependencyProperty.Register(
            "ReleaseCommand", typeof(ICommand), typeof(PressAndReleaseButton), new PropertyMetadata(null));
        /// <summary>
        /// The Release command to bind
        /// </summary>
        public ICommand ReleaseCommand
        {
            get { return (ICommand)GetValue(ReleaseCommandProperty); }
            set { SetValue(ReleaseCommandProperty, value); }
        }
        /// <summary>
        /// Default constructor registers mouse down and up events to fire commands
        /// </summary>
        public PressAndReleaseButton()
        {
            MouseDown += (o, a) => 
                     {
                         if (PressCommand.CanExecute(null)) PressCommand.Execute(null);
                     }
            MouseUp += (o, a) => 
                     {
                         if (ReleaseCommand.CanExecute(null)) ReleaseCommand.Execute(null);
                     } 
        }
    }
