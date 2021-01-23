            private void button1_Click(object sender, EventArgs e)
            {
                PrintDialog printDialog = new PrintDialog();
                PrintDocument printDoc = new PrintDocument();
    
                //PrintPage event to draw the textbox contents on page
                printDoc.PrintPage +=new PrintPageEventHandler(printDoc_PrintPage);
    
                printDoc.DocumentName = "Print";
    
                printDialog.Document = printDoc;
                printDialog.AllowSelection = true;
    
                printDialog.AllowSomePages = true;
    
                if (printDialog.ShowDialog() == DialogResult.OK)
                    printDoc.Print();
            }
            private void printDoc_PrintPage(object sender, PrintPageEventArgs e)
            {
                //Font
                Font f = new System.Drawing.Font("Arial",10,FontStyle.Bold);
    
                //Brush
                Brush b = new SolidBrush(Color.Black);
    
                //Where to draw the string
                PointF p = new PointF(10,10);
    
                //Draw some strings into the graphics
                e.Graphics.DrawString(m_txtFieldToSearch.Text,f,b,p);
            }
