        public void CustomMessage(string title, string dataTodisplay, string leftButton, string rightButton, MessageBoxIcon iconSet)
        {
            // Set up some properties.
            this.Font = SystemFonts.MessageBoxFont;
            this.ForeColor = SystemColors.WindowText;
            InitializeComponent();
            DisplayData = dataTodisplay;
            // Do some measurements with Graphics.
            SetFormData(dataTodisplay);
            // Set the title, and some Text properties.
            if (string.IsNullOrEmpty(title) == false)
            {
                this.Text = title;
            }
            // Set the left button, which is optional.
            if (string.IsNullOrEmpty(leftButton) == false)
            {
                this.ButtonOK.Text = leftButton;                 
            }
            Else
            {
              this.AcceptButton = ButtonCancel
              this.ButtonCancel.Visible = False
            }
            // Set the PictureBox and the icon.
            if ((iconSet != null))
            {
                ShowMessageBoxIcon(iconSet);
            }
