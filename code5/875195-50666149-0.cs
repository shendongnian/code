     private void invoiceGenerationToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach (Form form in Application.OpenForms)
            {
                if (form.GetType() == typeof(RETransactions.frmInvoicegeneration))
                {
                    form.Activate();
                    foreach (TabPage item in tabControl1.TabPages)
                    {
                        if (item.Text == "Invoice Generation")
                        {
                            tabControl1.SelectTab(item);
                        }
                    }
                    return;
                }
            }
            RETransactions.frmInvoicegeneration rTenancy = new RETransactions.frmInvoicegeneration();
            rTenancy.Show();
            rTenancy.TopLevel = false;
            TabPage tabp = new TabPage("Invoice Generation");
            tabp.Controls.Add(rTenancy);
            tabControl1.TabPages.Add(tabp);
            tabControl1.SelectTab(tabp);
            tabp.BackColor = Color.Gainsboro;
        }
