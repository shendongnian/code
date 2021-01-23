    private void spremiUDatotekuToolStripMenuItem1_Click(object sender, EventArgs e)
    {
    if (saveFileDialog1.ShowDialog() == DialogResult.OK)
    {
        System.IO.StreamWriter sw = new
        System.IO.StreamWriter(saveFileDialog1.FileName);
        for (int x = 0; x < dataGridView1.Rows.Count; x++)
        {
            for (int y = 0; y < dataGridView1.Columns.Count; y++)
            {
                sw.Write(dataGridView1.Rows[x].Cells[y].Value);
                if (y != dataGridView1.Columns.Count - 1) // Count - 1 is the last value. y will never reach count because you have "<" sign
                {
                    sw.Write("|");                    
                }
            }
            sw.WriteLine();
        }
        sw.Close();
    }
}
