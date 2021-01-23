    private void myChart_CustomizeLegend(object sender, CustomizeLegendEventArgs e)
    {
        foreach (LegendItem LI in e.LegendItems)
        {
            LI.Cells[1].Text = LI.Cells[1].Text.Replace('%', ' ');            
        }
    }
