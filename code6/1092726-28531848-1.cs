    public class APanel : UserControl
    {
        public APanel(AModel<Appellation, Bottle> model)
        {
            InitializeComponent();
            _titleLabel.SetTitleString(model.Title);
        }
    }
