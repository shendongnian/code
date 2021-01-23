    var data = new List<RepeaterData>();
    data.Add(new RepeaterData() { Time = DateTime.Today.AddHours(9), MonText = "123", TueText = null, WedText = null });
    data.Add(new RepeaterData() { Time = DateTime.Today.AddHours(10), MonText = null, TueText = "456", WedText = "789" });
    data.Add(new RepeaterData() { Time = DateTime.Today.AddHours(11), MonText = null, TueText = null, WedText = null });
    data.Add(new RepeaterData() { Time = DateTime.Today.AddHours(12), MonText = "123", TueText = null, WedText = null });
    rptTimeTable.DataSource = data;
    rptTimeTable.DataBind();
