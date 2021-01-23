    public static DataTable querySeat(string id)
    {
        string xmlStr = "";           //Place Your XML String here
        
        DataTable result = new DataTable("SeatData");
        DataColumn columnColumn = result.Columns.Add("column", typeof(Int32));
        DataColumn rowColumn = result.Columns.Add("row", typeof(Int32));
        DataColumn seatColumn = result.Columns.Add("seat", typeof(String));
        DataColumn deckColumn = result.Columns.Add("deck", typeof(Int32));
        DataColumn statusColumn = result.Columns.Add("status", typeof(Int32));
        XElement.Parse(HttpUtility.HtmlDecode(xmlStr)).Descendants("seat").ToList().ForEach(
           (element) =>
              {
                  DataRow row = result.NewRow();
                  row.SetField<int>(columnColumn, Convert.ToInt32(element.Parent.Parent.Attribute("id").Value));
                  row.SetField<int>(rowColumn, Convert.ToInt32(element.Parent.Attribute("id").Value));
                  row.SetField<string>(seatColumn, element.Attribute("number").Value);
                  int deckNo = -1;
                  if (element.Parent.Parent.Parent.Name.LocalName == "Lower-Deck")
                     deckNo = 1;
                  row.SetField<int>(deckColumn, deckNo);
                  string statusString = element.Attribute("status").Value;
                  int statusValue = -1;
                  if (statusString == "blank")
                      statusValue = 1;
                  else if (statusString == "0")
                      statusValue = 0;
                  row.SetField<int>(statusColumn, statusValue);
                  result.Rows.Add(row);
              }
           );
        return result;
    }
