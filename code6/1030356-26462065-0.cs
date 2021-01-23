    public class TitleBox : UserControl
    {
        public TitleLabel TitleLabel {get; set;}
    
        public TitleBox()
        {
            this.TitleLabel = new TitleTable();
            this.TitleLabel.Location = new Point(10, 10);
            this.Controls.Add(this.TitleLabel);
        }
    }
