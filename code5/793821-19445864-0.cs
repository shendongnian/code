      using (Form2 editForm = new Form2())
                {
                    editForm.ShowDialog();
                    if (editForm.DialogResult == DialogResult.OK)
                    {
                        MessageBox.Show("ok btn is pressed!");
                        editForm.Dispose();
                    }
                    else
                    {
                        MessageBox.Show("cancel btn is pressed!");
                        editForm.Dispose();
                    }
                }
