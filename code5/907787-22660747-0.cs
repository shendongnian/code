    public partial class CustomPanel : Panel {
        private PictureBox _imageBox;
        private Label _fileNameLabel;
        public CustomPanel() {} // This is most likely tied into the code behind file. Sorry, It's been a while since I've done WinForms
        public CustomPanel(string imageFileName, Panel parent) {
            // Set the source for the PictureBox.
            // Set the Text of the label.
            _parent = parent;
        }
    }
