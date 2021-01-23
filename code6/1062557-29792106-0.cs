            chartPage.set_HasAxis(Excel.XlAxisType.xlValue, Excel.XlAxisGroup.xlSecondary, true);
            chartPage.set_HasAxis(Excel.XlAxisType.xlSeriesAxis, Excel.XlAxisGroup.xlSecondary, true);
            chartPage.set_HasAxis(Excel.XlAxisType.xlCategory, Excel.XlAxisGroup.xlSecondary, true);
            chartPage.set_HasAxis(Excel.XlAxisType.xlValue, Excel.XlAxisGroup.xlPrimary, true);
            chartPage.set_HasAxis(Excel.XlAxisType.xlSeriesAxis, Excel.XlAxisGroup.xlPrimary, true);
            chartPage.set_HasAxis(Excel.XlAxisType.xlCategory, Excel.XlAxisGroup.xlPrimary, true);
            Excel.Series series = (Excel.Series)chartPage.SeriesCollection(1);
            series.AxisGroup = Excel.XlAxisGroup.xlSecondary;
            series.AxisGroup = Excel.XlAxisGroup.xlPrimary;
            series.Format.Line.Weight = 1.0F;
            series.Format.Line.Visible = MsoTriState.msoFalse;  //Tri-State 
            series.Format.Line.ForeColor.RGB = (int)Microsoft.Office.Interop.Excel.XlRgbColor.rgbWhite;
            series = (Excel.Series)chartPage.SeriesCollection(2);
            series.AxisGroup = Excel.XlAxisGroup.xlSecondary;
            series.AxisGroup = Excel.XlAxisGroup.xlPrimary;
            series.Format.Line.Weight = 1.0F;
            series.Format.Line.Visible = MsoTriState.msoFalse;  //Tri-State 
            series.Format.Line.ForeColor.RGB = (int)Microsoft.Office.Interop.Excel.XlRgbColor.rgbWhite;
            series = (Excel.Series)chartPage.SeriesCollection(3);
            series.AxisGroup = Excel.XlAxisGroup.xlSecondary;
            series.AxisGroup = Excel.XlAxisGroup.xlPrimary;
            series.Format.Line.Weight = 1.0F;
            series.Format.Line.Visible = MsoTriState.msoFalse;  //Tri-State 
            series.Format.Line.ForeColor.RGB = (int)Microsoft.Office.Interop.Excel.XlRgbColor.rgbWhite;
            series = (Excel.Series)chartPage.SeriesCollection(4);
            series.AxisGroup = Excel.XlAxisGroup.xlSecondary;
            series.AxisGroup = Excel.XlAxisGroup.xlPrimary;
            series.Format.Line.Weight = 1.0F;
            series.Format.Line.Visible = MsoTriState.msoFalse;  //Tri-State 
            series.Format.Line.ForeColor.RGB = (int)Microsoft.Office.Interop.Excel.XlRgbColor.rgbWhite;
            Excel.Axis axis;
            axis = (Excel.Axis)chartPage.Axes(Excel.XlAxisType.xlCategory, Excel.XlAxisGroup.xlPrimary);
            axis.HasTitle = true;
            axis.AxisTitle.Text = xmsg;
            axis = (Excel.Axis)chartPage.Axes(Excel.XlAxisType.xlValue, Excel.XlAxisGroup.xlPrimary);
            axis.HasTitle = true;
            axis.AxisTitle.Text = ymsg;
        }
