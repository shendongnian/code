        protected void ImageButtonPopulateChart_Click(object sender, ImageClickEventArgs e)
        {
            int? genderID = null;
            Dictionary<object, object> myXyDataObjects = new Dictionary<object, object>();
    
            ChartImplementor charting = new ChartImplementor()
            {
                ChartTitle = "A digram illustrates Employees ",
                ChartSubTitle = "HSBC Bank.",
                XTitle = "Employees",
                YTitle = "Salaries"
    
            };
            
            
            var chartQuery = SchoolDC.usp_Chart_Report(SchoolID, genderID, statusID).ToList();
            foreach (var item in chartQuery)
            {
                myXyDataObjects.Add(item.LevelName, item.stCount);
            }
    
            ScriptManager.RegisterStartupScript(UpdatePanel1,
    UpdatePanel1.GetType(),
    "script",charting.GenerateChartJS(charting, ChartTypes.column, myXyDataObjects, "container"), // container is the ID of the Div Control which will populate the Chart.
    false);
    }
