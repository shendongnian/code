    public partial class CollapsiblePanel : UserControl
    {
        public enum CollapseDirection
        {
            None,
            Up,
    		Right,
    		Down,
    		Left,
    		All
    	}
    
        # region Collapse Direction
    
    	[Browsable(true), DefaultValue("All"), Description("Direction panel collapses. 0-none, 1-up, 2-right, 3-down, 4-left, 5-all")]
        [ListBindable(true), Editor(typeof(ComboBox), typeof(UITypeEditor))]
        private CollapseDirection _direction = CollapseDirection.All;
        public CollapseDirection Direction
        {
            get { return _direction; }
            set
            {
                _direction = value;
                callCollapseDirectionChanged();
            }
        }
    
        public event Action CollapseDirectionChanged;
        protected void callCollapseDirectionChanged()
        {
            Action handler = CollapseDirectionChanged;
            DisplayButtons();
            if (handler != null)
            {
                handler();
            }
        }
        # endregion
    
        public CollapsiblePanel()
        {
            InitializeComponent();
        }
    
        private void DisplayButtons()
        {
            switch (_direction)
            {
                case CollapseDirection.None:
                    buttonDown.Visible = false;
                    buttonUp.Visible = false;
                    buttonRight.Visible = false;
                    buttonLeft.Visible = false;
                    break;
    
                case CollapseDirection.Up:
                    buttonDown.Visible = false;
                    buttonUp.Visible = true;
                    buttonRight.Visible = false;
                    buttonLeft.Visible = false;
                    break;
    
                case CollapseDirection.Right:
                    buttonDown.Visible = false;
                    buttonUp.Visible = false;
                    buttonRight.Visible = true;
                    buttonLeft.Visible = false;
                    break;
    
                case CollapseDirection.Down:
                    buttonDown.Visible = true;
                    buttonUp.Visible = false;
                    buttonRight.Visible = false;
                    buttonLeft.Visible = false;
                    break;
    
                case CollapseDirection.Left:
                    buttonDown.Visible = false;
                    buttonUp.Visible = false;
                    buttonRight.Visible = false;
                    buttonLeft.Visible = true;
                    break;
    
                case CollapseDirection.All:
                    buttonDown.Visible = true;
                    buttonUp.Visible = true;
                    buttonRight.Visible = true;
                    buttonLeft.Visible = true;
                    break;
            }
        }
    }
