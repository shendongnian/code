            In code behind:
            List<object> values_List = new List<object>();
            object[] values = values_List.ToArray();
            Highcharts chart1 = new Highcharts("Chart1")
            .InitChart(new Chart { Height = 300, Width = 400, Type = ChartTypes.Column })
            .SetSeries(new Series { Data = new Data(values)});            
            ltrChart1.Text = chart1.ToHtmlString();
            In aspx:
            <asp:Literal ID="ltrChart1" runat="server"></asp:Literal>
