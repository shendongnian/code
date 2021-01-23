        public interface IViewModelComponent
        {
            event EventHandler<UserInputEventArgs> UserInputError;
        }
        public class VMBase: IViewModelComponent
        {
            public event EventHandler<UserInputEventArgs> UserInputError;
            protected virtual void OnUserInputError(UserInputEventArgs e)
            {
                EventHandler<UserInputEventArgs> handler = UserInputError;
                if (handler != null)
                {
                    handler(this, e);
                }
            }
        }
        public class UserInputEventArgs: EventArgs
        {
            public string ErrorMessage { get; set; }
        }
        public class AssetForm : VMBase
        {
            private void SomethingBadHappened()
            {
                UserInputEventArgs args = new UserInputEventArgs;
                args.ErrorMessage = "This bad thing hapened";
                OnUserInputError(args);
            }
        }
        public class ViewUcBase : UserControl, IViewComponent
        {
            //EDIT: Forgot the next line
            public IViewModelComponent VM { get; set; }
            
            //Default implementation of what should be done with the event.
            public virtual void UserInputErrorHandler(object sender, UserInputEventArgs e)
            {
                string header = string.Format("{0} - InputError",DisplayName);
                MessageBox.Show(e.ErrorMessage,header,MessageBoxButton.OK,MessageBoxImage.Exclamation);
            }
            //Subscribing to the event in the base class so it always gets handled.
            public ViewUcBase()
            {
                VM.UserInputError += UserInputErrorHandler; //No overload for 'UserInputErrorHandler' matches delegate 'System.EventHandler'
            }
        }
}
