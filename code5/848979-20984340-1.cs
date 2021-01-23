    public class UserControlViewModel : BaseViewModel
    {
      …your code here
      public RelayCommand InvalidateGridCommand { get; private set; }
      public UserControlViewModel()
      {
        InvalidateGridCommand = new RelayCommand( () => InvalidateGrid() );
      }
      private void InvalidateGrid()
      {
        var mainvm = SimpleIoc.Default.GetInstance(MainViewModel);
        mainvm.IsValid = false;
      }
    }
