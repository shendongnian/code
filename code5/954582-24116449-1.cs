    DataSet dataSet;
    ConnectionClass.GetInstance().connection_string = Properties.Settings.Default.MindMuscleConnectionString;
    ConnectionClass.GetInstance().Sql = "Select Count(MemberInfo.memberName) as 'Members', CompetitionName as 'Competition' FROM MemberInfo, MemberBodyInfo, Competition WHERE MemberInfo.memberID = MemberBodyInfo.memberID AND MemberBodyInfo.weight >= Competition.CompetitionCategory and MemberBodyInfo.weight <= Competition.CompetitionCategory + 5 group by CompetitionName;";
    dataSet = ConnectionClass.GetInstance().GetConnection;
    chart1.Series["Series1"].Name = "Members";
    chart1.Series["Members"].YValueMembers = "Members";
    chart1.Series["Members"].XValueMember = "Competition";
    chart1.Series.Add("Members2");
    chart1.Series["Members2"].ChartType = SeriesChartType.StackedColumn;
    chart1.Series["Members2"].IsValueShownAsLabel = true;
    chart1.Series["Members2"].YValueMembers = "Members";
    chart1.Series["Members2"].XValueMember = "Competition";
    this.chart1.Titles.Add("Competition Participants");   // Set the chart title
    chart1.Series["Members"].ChartType = SeriesChartType.StackedColumn;
    chart1.Series["Members"].IsValueShownAsLabel = true;  // To show chart value 
    chart1.DataSource = dataSet;
    chart1.DataBind();
