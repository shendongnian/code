           private void button1_Click(object sender, EventArgs e)
            {
                PrintDialog printdg = new PrintDialog();
                if (printdg.ShowDialog() == DialogResult.OK)
                {
                    PrintDocument pd = new PrintDocument();
                    pd.PrinterSettings = printdg.PrinterSettings;
                    pd.PrintPage += PrintPage;
                    pd.Print();
                    pd.Dispose();
                }
            }
            private void PrintPage(object o, PrintPageEventArgs e)
            {
                System.Drawing.Image img = System.Drawing.Image.FromFile(@"C:\Users\therath\Desktop\372\a.jpg");
                // You can replace your logic @ here to load the image or whatever you want
                Point loc = new Point(100, 100);
                e.Graphics.DrawImage(img, loc);
            }
