    Customer_Regisration_Form cf;
    private void NewRegToolStripMenuItem_Click(object sender, EventArgs e)
    {
        if (cf == null || cr.IsDisposed)
        { cf = new Customer_Regisration_Form();
            cf.MdiParent = this;
        }
        cf.Show();
    }
