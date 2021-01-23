    public class UncheckableRadioButton : RadioButton
    {
       protected override void OnToggle()
       {
          if (IsChecked == true)
             IsChecked = false;
          else base.OnToggle();
       }
    }
