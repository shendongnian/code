    public void display(int userid) {
     var Charts = chartGroup.Descendants("charts")
                            .Elements("chart")
                            .Where(x =>  x.Attribute("id").Value == userid.ToString())
                            .Select(x => x.Attribute("name").Value).ToList();
    }
