    public class MyExtendedEntryRenderer : EntryRenderer
    {
        protected override void OnElementChanged(ElementChangedEventArgs<Entry> e)
        {
            base.OnElementChanged(e);
            if (Control != null)
            {
                new Handler().PostDelayed(delegate
                {
                    var imm = (InputMethodManager)Control.Context.GetSystemService(Context.InputMethodService);
                    var result = imm.HideSoftInputFromWindow(Control.WindowToken, 0);
                }, 500L);
            }
        }
    }
