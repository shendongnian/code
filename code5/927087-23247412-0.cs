    public class BasePopup : BaseForm
    {
        private Panel controlPanel;
        private Label controlLabel; 
    
        public BasePopup()
        {
            controlPanel = new Panel { Dock = DockStyle.Fill, BorderStyle = BorderStyle.Fixed3D };
            this.Controls.Add(controlPanel);
    
            controlLabel = new Label { Location = new Point(30, 30), Text = "AAA" };
            controlPanel.Controls.Add(controlLabel);
        }
     }
