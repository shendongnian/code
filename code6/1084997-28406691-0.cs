        private void dgData_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            picData.ImageLocation = dgData.CurrentRow.Cells[1].Value.ToString();
            picData.SizeMode = PictureBoxSizeMode.StretchImage;
        }
