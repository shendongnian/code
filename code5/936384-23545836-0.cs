    public class ReportData
	{
		public IEnumerable<SASFStringified> GetLongReportData(string commSubGp)
		{
			var context = new Entities();
			string myDate = "2014-03-18";
			DateTime date = Convert.ToDateTime(myDate);
			var result = new List<SASF>();
			if (commSubGp == "F00")
			{
				result = (from a in context.SASF
						  where a.RDate == date &&
						  a.COMM_SGP.CompareTo("F00") <= 0
						  orderby a.Conmkt, a.MKTTITL descending
						  select a).ToList();
				var stringifiedResult = new List<SASFStringified>();
				foreach (var sasf in result)
				{
					stringifiedResult.Add(new SASFStringified
					{
						ID = sasf.ID,
						Field1 = sasf.Field1.HasValue ? sasf.Field1.Value.ToString() : "non-reportable",
						Field2 = sasf.Field2.HasValue ? sasf.Field2.Value.ToString() : "non-reportable",
						DateField = sasf.DateField.ToShortDateString()
					});
				}
				return stringifiedResult;
			}
			return results;
		}
	}
	public class SASF
	{
		public int ID { get; set; }
		public decimal? Field1 { get; set; }
		public decimal? Field2 { get; set; }
		public DateTime DateField { get; set; }
	}
	public class SASFStringified
	{
		public int ID { get; set; }
		public string Field1 { get; set; }
		public string Field2 { get; set; }
		public string DateField { get; set; }
	}
