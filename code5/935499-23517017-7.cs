    public partial class Form2 : Form
    {
        public Form2(Form1 opener)
        {
            // this is a constructor
            this.Opener = opener;
        }
        private Form1 Opener { get; set; }
        private void SomeMethod() 
        {
            this.Opener.UserName = "Tim";
            this.Opener.UserNameEditable = false;
        }
        // ...
    }
