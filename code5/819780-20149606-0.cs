     private int counter;
        private void PrintTextBox(object sender, PrintPageEventArgs e)
        {
            for (int i = 0; i < 10; i++) //Ten line sper page
            {
                counter += 1;
                e.Graphics.DrawString(textBox1.Lines[counter], textBox1.Font, Brushes.Black, 50, 20);
            }
            if (counter==textbox1.lines.count)
            {
                e.HasMorePages = false;
            }
            else
            {
                e.HasMorePages = true;
            }
        }
        private void printListButton_Click(object sender, EventArgs e)
        {
            counter = textBox1.lines.count;
            PrintDocument pd = new PrintDocument();
            pd.PrintPage += PrintTextBox;
            PrintPreviewDialog ppd = new PrintPreviewDialog();
            ppd.Document = pd;
            ppd.ShowDialog();
        }
