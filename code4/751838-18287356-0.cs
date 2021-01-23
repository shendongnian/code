    private void button6_Click(object sender, EventArgs e)
    {
        using(StreamReader Printfile = new StreamReader("c:\\testDir1\\Password.txt))
        {
            try
            {
                Font printFont = new Font("Arial", 10);
                PrintDocument docToPrint = new PrintDocument();
                docToPrint.DocumentName = "Password"; //Name that appears in the printer queue
                docToPrint.PrintPage += (s, ev) =>
                {
                    float linesPerPage = 0;
                    float yPos = 0;
                    int count = 0;
                    float leftMargin = ev.MarginBounds.Left;
                    float topMargin = ev.MarginBounds.Top;
                    string line = null;
                    // Calculate the number of lines per page.
                    linesPerPage = ev.MarginBounds.Height / printFont.GetHeight(ev.Graphics);
                    // Print each line of the file. 
                    while (count < linesPerPage && ((line = streamToPrint.ReadLine()) != null))
                    {
                        yPos = topMargin + (count * printFont.GetHeight(ev.Graphics));
                        ev.Graphics.DrawString(line, printFont, Brushes.Black,  leftMargin, yPos, new StringFormat());
                        count++;
                    }
                    // If more lines exist, print another page. 
                    if (line != null)
                        ev.HasMorePages = true;
                    else
                        ev.HasMorePages = false;
                };
                docToPrint.Print();
            }
            catch (System.Exception f)
            {
                MessageBox.Show(f.Message);
            }
        }
    }
