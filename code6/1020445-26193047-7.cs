    public partial class MyView : UserControl
{
...
	public static readonly DependencyProperty ErrorMessageProperty =
            DependencyProperty.Register("ErrorMessage", typeof (string), typeof (MyView),
                     new PropertyMetadata((o, args) =>
                     {
						// Display childwindow when message is changed
						string message = args.NewValue as string;
						if(message!=null)
						{
                                ConfirmationWindow cfw = new ConfirmationWindow();
    							cfw.SetMessage(message);
    							cfw.Show(); 
						}
                     }));
        public string ErrorMessage
        {
            get { return (string)GetValue(ErrorMessageProperty); }
            private set { SetValue(ErrorMessageProperty, value); }
        }
