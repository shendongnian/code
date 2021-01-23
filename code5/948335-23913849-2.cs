    public class CustomTextBox : TextBox
        {
            public Label AssociatedLabel { get; set; }
    
            public CustomTextBox():base()
            {
                this.ParentChanged += new EventHandler(CustomTextBox_ParentChanged);
            }
    
            void CustomTextBox_ParentChanged(object sender, EventArgs e)
            {
                this.AutoAddAssociatedLabel();
            }
    
            private void AutoAddAssociatedLabel()
            {
                if (this.Parent == null) return;
    
                AssociatedLabel = new Label();
                AssociatedLabel.Text = "Associated Label";
                AssociatedLabel.Padding = new System.Windows.Forms.Padding(3);
    
                Size s = TextRenderer.MeasureText(AssociatedLabel.Text, AssociatedLabel.Font);
                AssociatedLabel.Location = new Point(this.Location.X - s.Width - AssociatedLabel.Padding.Right, this.Location.Y);
    
                this.Parent.Controls.Add(AssociatedLabel);
            }
        }
