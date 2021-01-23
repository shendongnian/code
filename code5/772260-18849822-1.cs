            PrintDocument pd = new PrintDocument();
            pd.PrintPage += new PrintPageEventHandler(PrintPage);
            PrintDialog pdi = new PrintDialog();
            pdi.Document = pd;
            if (pdi.ShowDialog() == DialogResult.OK)
            {
                pd.DocumentName = documentName;
                pd.Print();
            }
            else
            {
               MessageBox.Show("Print Cancelled");
            }
