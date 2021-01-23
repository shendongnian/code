    private void cmdload_Click(object sender, EventArgs e)
    {
        OpenFileDialog openFileDialog1 = new OpenFileDialog();
        openFileDialog1.InitialDirectory = "\\Yamaha";
        openFileDialog1.FilterIndex = 2;
        openFileDialog1.RestoreDirectory = true;
        if (openFileDialog1.ShowDialog() == DialogResult.OK)
        {
           try
           {
               string[] fileLines= System.IO.File.ReadAllLines(openFileDialog1.FileName);
               IEnumerable<string[]> splitedLines = fileLines.Select(c => c.Split(new string[]{" "}, StringSplitOptions.RemoveEmptyEntries));
               var data = splitedLines.Select(c => new
               {
                   Point = c[0],
                   X = c[2],//c[1] would be "=" sign
                   Y = c[3],
                   Z = c[4],
                   R = c[5],
                   A = c[6],
                   B = c[7],
                   C = c[8]
               });
               dataGridView1.DataSource = data.ToArray();
            }
            catch (Exception ex)
            {
                 MessageBox.Show("Error: Something is not right. Original error: " + ex.Message);
            }
        }
    }
