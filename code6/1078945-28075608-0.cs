    protected void chtBillableNonBillable_TakeDataSource(object sender, Shield.Web.UI.ChartTakeDataSourceEventArgs e)
{
    var dataHours = new List<HoursType>()
    {
        //This month
        new HoursType() { Billable = Math.Round(billThisMonth / totalThisMonth * 100, 2),
            NonBillable = Math.Round(nonBillThisMonth / totalThisMonth * 100, 2), strTest = nonBillThisMonth},
        //Last month
        new HoursType() { Billable = Math.Round(billLastMonth / totalLastMonth * 100, 2), 
            NonBillable = Math.Round(nonBillLastMonth / totalLastMonth * 100, 2), strTest = nonBillLastMonth},
        //YTD
        new HoursType() { Billable = Math.Round(billYTD / totalYTD * 100, 2), 
            NonBillable = Math.Round(nonBillYTD / totalYTD * 100, 2), strTest = nonBillYTD}
    };
    chtBillableNonBillable.DataSource = dataHours;
    Page.RegisterArrayDeclaration("strTests", string.Join(",", dataHours.Select(s => s.strTest.ToString(CultureInfo.InvariantCulture))));
