    SaveFileDialog sfd = new SaveFileDialog();
    sfd.Filter = ".xlsx Files (*.xlsx)|*.xlsx";
    do
    {
        if (sfd.ShowDialog() == DialogResult.OK)
        {
            string path = Path.GetDirectoryName(sfd.FileName);
            string filename = Path.GetFileNameWithoutExtension(sfd.FileName);
            try
            {
                toSave[i].SaveAs(infor);
                break;
            }
            catch (System.IO.IOException)
            {
                //inform user file exists or that there was another issue saving to that file name and that they'll need to pick another one.
            }
        }
    } while (true);
    MessageBox.Show("Succesvol opgeslagen als: " + infor);
