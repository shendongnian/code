    public partial class FormContainer : Form {
        public FormContainer() {
            InitializeComponent();
            this.IsMdiContainer = true;
            // if you're not excited about the new form's backcolor
            // just change it back to the original one like so
            // note: The dark gray color which is shown on the container form
            //       is not it's actual color but rather a misterious' control's color.
            //       When you turn a plain ol' form into an MDIContainer
            //       you're actually adding an MDIClient on top of it
           
            var theMdiClient = this.Controls
                .OfType<Control>()
                .Where(x => x is MdiClient)
                .First();
            theMdiClient.BackColor = SystemColors.Control;
        }
        private void FormContainer_Load(object sender, EventArgs e) {
            var child = new FormChild();
            child.MdiParent = this;
            child.Show();
        }
    }
