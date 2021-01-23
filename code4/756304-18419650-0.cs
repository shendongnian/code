    public class ListViewModel : BaseListTestViewModel
    {
        private int i = 0;
        public ICommand HelloCommand
        {
            get { return new MvxCommand(() => Mvx.Trace("Hello " + ++i));}
        }
    }
