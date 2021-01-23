    .SetPlotOptions(new PlotOptions
                  {
                      Bar = new PlotOptionsBar
                      {
                          Stacking = Stackings.Percent,
                          BorderWidth =0,
                          BorderColor = System.Drawing.Color.Gray,
                          Shadow = false,
                          
                          DataLabels = new PlotOptionsBarDataLabels
                          {
                              Enabled = true,
                              Formatter = "function() { return '<div class=\"Test\"/></br>&nbsp;&nbsp;&nbsp;&nbsp;'+this.series.name;}",
                              Color = System.Drawing.Color.Black,
                              UseHTML=true,
                              Style = "fontSize: '12px', fontFamily: 'Arial', fontBold: 'true', color: 'Black'"
                          },
                          PointWidth = 35,
                          Point = new PlotOptionsBarPoint { },
                      }
                  })
