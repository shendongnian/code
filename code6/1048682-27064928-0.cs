      private void _openButton_Click(object sender, EventArgs e)
        {
            DialogResult result = openFileDialog.ShowDialog();
            if (result == DialogResult.OK) {
                _wordApp = new Microsoft.Office.Interop.Word.Application();
                _wordApp.Documents.Open(openFileDialog.FileName);
                _wordApp.Visible = true;
            }
        }
