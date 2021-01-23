    public void exec_RT(string tickername, bool isSubIndex)
        {
            DataTable RT_dt = Price_dt(tickrname, isSubIndex);
            Infragistics.Win.UltraWinChart.UltraChart toplot = new Infragistics.Win.UltraWinChart.UltraChart();
            toplot = forms.Real_timeAlpha;
            //global variable of the type DataTable
            globalTable = RT_dt;
            configgraph(RT_dt, toplot);
        }
