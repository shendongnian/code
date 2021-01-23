                var multas = from multa in db.Multa select multa;
                int MultaSinPago = multas.Where(s => s.Estado == "sin pago").Count();
                int MultaPagado = multas.Where(s => s.Estado == "Pagado").Count();
                TempData["CountMulta"] = (MultaPagado + MultaSinPago).ToString();
                Highcharts chart = new Highcharts("chart")
                    .SetTitle(new Title() { Text = "Multas"})
                    .InitChart(new Chart())
                    .SetPlotOptions(new PlotOptions
                    {
                        Pie = new PlotOptionsPie
                        {
                            AllowPointSelect = true,
                            Cursor = Cursors.Pointer,
                            ShowInLegend = true,
                            Events = new PlotOptionsPieEvents { Click = "function(event) { alert('The slice was clicked!'); }" },
                            Point = new PlotOptionsPiePoint { Events = new PlotOptionsPiePointEvents { LegendItemClick = "function(event) { if (!confirm('Do you want to toggle the visibility of this slice?')) { return false; } }" } }
                        }
                    })
                    .SetSeries(new Series
                    {
                        Type = ChartTypes.Pie,
                        Name = "Cantidad",
                        Data = new Data(new object[]
                                        {
                                            new object[] { "Pagado", MultaPagado},
                                            new object[] { "Sin pago", MultaSinPago}
                                        })
                    });
                   ViewBag.Chart1Model = chart;
    
                return View();
