    public abstract class BaseViewModel
    {
      public bool ShowRadioButtons { get; protected set; }
    }
    public class EditViewModel : BaseViewModel
    {
      public EditViewModel()
      {
        ShowRadioButtons = true;
      }
    }
    public class CreateViewModel : BaseViewModel
    {
      public CreateViewModel()
      {
        ShowRadioButtons = false;
      }
    }
