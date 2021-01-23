    public static class ChartExtensions
	{
		public static ChartBuilder<PropertyPivotAverageAmountPerMonth_Result> AnnualComparison(this HtmlHelper html, int id)
		{
			MyDatabaseEntities db = new MyDatabaseEntities();
			var results = db.PropertyPivotAverageAmountPerMonth(id);
			ChartBuilder<PropertyPivotAverageAmountPerMonth_Result> chart = new ChartBuilder<PropertyPivotAverageAmountPerMonth_Result>(html, results);
			
			chart.AxisX(axisX => axisX.CategoricalValues("Jan", "Feb", "Mar", "Apr", "May", "Jun", "Jul", "Aug", "Sep", "Oct", "Nov", "Dec"));
			chart.PrimaryHeader(header => header.Text("Annual Cost Comparisons"));
			
			foreach (var year in results)
			{
				chart.DataSeries(s => s.Line()
					.CollectionAlias(year.Year.ToString())
					.Data(new object[]
						{
							new { x=0, y=year.C1 },
							new { x=1, y=year.C2 },
							new { x=2, y=year.C3 },
							new { x=3, y=year.C4 },
							new { x=4, y=year.C5 },
							new { x=5, y=year.C6 },
							new { x=6, y=year.C7 },
							new { x=7, y=year.C8 },
							new { x=8, y=year.C9 },
							new { x=9, y=year.C10 },
							new { x=10, y=year.C11 },
							new { x=11, y=year.C12 }
						}));
			}
			return chart;
		}
