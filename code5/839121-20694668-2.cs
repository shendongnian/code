    private void Window_Load(object sender, EventArgs e)
    {
        System.Windows.Forms.SaveFileDialog saveDlg = new System.Windows.Forms.SaveFileDialog();
        saveDlg.DefaultExt = ".rtf";
        saveDlg.Filter = "RTF Documents (.rtf)|*rtf";
        RetHere:
        if (saveDlg.ShowDialog() == System.Windows.Forms.DialogResult.Yes)
        {        
            string filename = saveDlg.FileName;
            System.IO.File.Create(filename);
        }
        else {
           MessageBox.Show("Your message here!", "Save", MessageBoxButtons.OK);
           goto RetHere;
        }
    }
