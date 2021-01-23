    bool deleted = false;
    try
    {
        ChartObject myChart = Sheet.ChartObjects("Chart01");
        myChart.Delete();
        deleted = true;
    }
    catch (Exception e)
    {
        // Chart with this name couldn't be found
        MessageBox.Show(e.ToString());
    }
    finally
    {
        MessageBox.Show(deleted.ToString());
    }
