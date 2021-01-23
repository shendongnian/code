    private void chkCPTData_Click(object sender, EventArgs e)
    {
        for (int rows = CPTData.Rows.Count - 1; rows >=0; rows--)
        {
            double SampleDepth =(double)System.Convert.ToSingle(CPTData.Rows[rows].Cells[0].Value);
            if (SampleDepth > (double)System.Convert.ToSingle(analysisDepth.Text))
            {
                CPTData.Rows.RemoveAt(rows);
            }
        }
        CPTData.Refresh();          
    }
