    [DefaultProperty("Text")]
    [ToolboxData("<{0}:TrimmedTextBox runat=server></{0}:TrimmedTextBox>")]
    public class TrimmedTextBox : TextBox
    {
        [Category("Appearance")]
        public override string Text
        {
                get { return base.Text.Trim(); }
                //Automatically trim the Text property as it gets assigned
                set { base.Text = value.Trim(); }
        }
    }
