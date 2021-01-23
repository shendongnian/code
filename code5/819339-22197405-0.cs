            In code behind:
            Highcharts chart1 = new Highcharts("Chart1")
            .InitChart(new Chart { Height = 300, Width = 400, Type = ChartTypes.Column })
            .SetSeries(new Series { Data = new Data(object[] { 1, 2, 3, 4, 5 } });            
            ltrChart1.Text = chart1.ToHtmlString();
            In aspx:
            <asp:Literal ID="ltrChart1" runat="server"></asp:Literal>
