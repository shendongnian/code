    private void Form1_Load(object sender, EventArgs e)
        {
            using (var db = new db())
            {
                // now our dataGridView will show us 'docs'
                docsBindingSource.DataSource = db.docs.ToList();
            }
            
        }
    // a.k.a. Insert event
    private async void addBtn_Click(object sender, EventArgs e)
        {
            using (frmAddEdit frm = new frmAddEdit())
            {
                frm.ShowDialog();
                // after I Show frmAddEdit Form, i will change his DialogResult
                // in some period of time
                if (frm.DialogResult == DialogResult.OK)
                {
                    try
                    {
                        // then i make db object
                        using (var db = new db())
                        {
                            // adding data
                            var added = db.docs.Add(new docs()
                            {
                                docsAgent = frm.docsInfo.docsAgent,
                                docsStaff = frm.docsInfo.docsStaff,
                                docsType = frm.docsInfo.docsType
                            });
                            // saving
                            await db.SaveChangesAsync();
                            // and updating my bindingSource, which is a source for
                            // my dataGridView
                            docsBindingSource.Add(added);
                            
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message, "Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        throw;
                    }
                }
            }
        }
