    public partial class ToggleableExpanderForm : Form
    {
        public ToggleableExpanderForm()
        {
            InitializeComponent();
            SizeChanged += (s, args) => 
            {  
                if (_LastSize.HasValue)
                {
                    var diff = Size - _LastSize.Value;
                    if (_LastHeight.HasValue
                        && !IgnoreNextResizeForLastHeightAdjustment)
                    {
                        _LastHeight += diff.Height;
                    }
                }
                _LastSize = Size;
            };
        }
        private Size? _LastSize;
        private bool IgnoreNextResizeForLastHeightAdjustment = true;
        private int? _LastHeight;
        private void btnTogglePanel_Click(object sender, EventArgs e)
        {
            var newVisibility = !pnlToggled.Visible;
            int heightAdjustment = 0;
            if (newVisibility)
            {
                if (_LastHeight.HasValue)
                {
                    heightAdjustment = _LastHeight.Value;
                    _LastHeight = null;
                }
            }
            else
            {
                _LastHeight = pnlToggled.Height;
                heightAdjustment = -pnlToggled.Height;
            }
            pnlToggled.Visible = newVisibility;
            IgnoreNextResizeForLastHeightAdjustment = true;
            Height += heightAdjustment;
        }
    }
