    private void Grd_Detail_FormattingRow(object sender, Janus.Windows.GridEX.RowLoadEventArgs e)
    {
        int i = 1;
        for (i = 0; i < Grd_Detail.RowCount; i++)
        {
                if (e.Row.RowType == Janus.Windows.GridEX.RowType.Record)
                {           
                     int s1=Int32.Parse(Grd_Detail.GetRow(i).Cells["Column1"].Value.ToString());
                     int s2=Int32.Parse(Grd_Detail.GetRow(i).Cells["Column2"].Value.ToString());      
                     Grd_Detail.GetRow(i).Cells["Column3"].Value=s1+s2;
                }
            }
        }
    }
