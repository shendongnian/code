    public class DoubleClickButton : Button
    {
        public DoubleClickButton()
        {
            this.SetStyle(ControlStyles.StandardClick | ControlStyles.StandardDoubleClick, true);
        }
    }
