    if (graficoKVm.Series[0].Points.Count > 3659)
    {
        graficoKVm.Series[0].Points.AddXY(DateTime.Now.ToOADate(), _sensorCampoEletroMagnetico.kVm);
        if (!graficoKVm.ChartAreas[0].AxisX.ScaleView.IsZoomed &&
            !graficoKVm.ChartAreas[0].AxisY.ScaleView.IsZoomed &&
            !graficoKVm.ChartAreas[0].AxisY2.ScaleView.IsZoomed &&
            !graficoKVm.ChartAreas[0].AxisX2.ScaleView.IsZoomed)
        {
            while (graficoKVm.Series[0].Points.Count > 3660)
            {
                graficoKVm.Series[0].Points.RemoveAt(0);
            }
            graficoKVm.ResetAutoValues();
        }
    }
