    public partial class ParentForm : Form
    {
        public Base()
        {
            this.Load += new System.EventHandler(this.FormLoad); 
            this.Resize += new System.EventHandler(this.frmBranchDetails_Resize);        
        }
        protected virtual void FormLoad(object sender, EventArgs e)         
        {             
            this.WindowState = FormWindowState.Maximized;         
        }
       
        private void frmBranchDetails_Resize(object sender, EventArgs e)
        {
            panel1.Left = (this.ClientSize.Width - panel1.Width) / 2;
            panel1.Top = (this.ClientSize.Height - panel1.Height) / 2;
        }
    }
