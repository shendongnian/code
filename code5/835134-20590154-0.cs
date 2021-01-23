    public partial class FormMain : Form
    {
        FormTest ftmTest;
        ...
        void testToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if(frmTest == null)
            {
                frmTest = new FormTest();
                frmTest.MdiParent = this;
            }
            frmTest.Show();
            frmTest.BringToFront();
        }
