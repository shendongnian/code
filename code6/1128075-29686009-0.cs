    public partial class CustomButton : Control
    {
        private ButtonType _buttonType = ButtonType.OnOff;
        private CustomButtonOptions _options = new OnOffButtonOptions();
        [RefreshProperties(System.ComponentModel.RefreshProperties.All)]
        public ButtonType ButtonType
        {
            get { return _buttonType; }
            set
            {
                switch (value)
                {
                    case DynamicPropertiesTest.ButtonType.Momentary:
                        _options = new MomentaryButtonOptions();
                        break;
                    default:
                        _options = new OnOffButtonOptions();
                        break;
                }
                _buttonType = value;
            }
        }
        [TypeConverter(typeof(ExpandableObjectConverter))]
        public CustomButtonOptions ButtonOptions
        {
            get { return _options; }
            set { _options = value; }
        }
        public CustomButton()
        {
            InitializeComponent();
        }
    }
    public enum ButtonType
    {
        Momentary,
        OnOff
    }
    public abstract class CustomButtonOptions
    {
    }
    public class MomentaryButtonOptions : CustomButtonOptions
    {
        public int Minimum_Press_Time { get; set; }
        public override string ToString()
        {
            return Minimum_Press_Time.ToString();
        }
    }
    public class OnOffButtonOptions : CustomButtonOptions
    {
        public override string ToString()
        {
            return "No Options";
        }
    }
