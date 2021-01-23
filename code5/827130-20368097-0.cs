    interface IDialogFooterText
    {
        string GetFooterDisplay();
        int CurrentPageIndex { get; set; }
    }
    
    public class DialogBoxFactory
    {
        IDialogFooterText _footerText = // ...
    
        void Start()
        {
            _footerText.CurrentPageIndex += 1;
    
            Debug.Log( _footerText.GetFooterDisplay() );
        }
    }
