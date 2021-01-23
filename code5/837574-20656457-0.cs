    public class floatingText : System.Windows.Forms.Label
    {
        public floatingText()
        {
            this.Text = "Words go here";
            this.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.ForeColor = Color.WhiteSmoke;
            this.BackColor = Color.Black;
            this.TransparencyKey = Color.Black;
        }
    }
