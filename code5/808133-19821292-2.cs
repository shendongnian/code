     private void Form1_FormClosing(object sender, FormClosingEventArgs e)
                {
                        // If the Spreadsheet has been changed since the user opened it and
                        // the user has requested to Close the window, then prompt him to Save
                        // the unsaved changes.
                        if (SpreadSheet.Changed)
                        {
                            DialogResult UserChoice = MessageBox.Show("Would you like to save your changes?", "Spreadsheet Utility",
                                    MessageBoxButtons.YesNoCancel, MessageBoxIcon.Warning);
        
                            switch (UserChoice)
                            {
                                case DialogResult.Yes:
                                    SaveFileOperation();
                                    break;
                                case DialogResult.No:
                                    break;
                                case DialogResult.Cancel:
                                    e.Cancel = true;
                                    break;                              
                            }
                        }
                }
