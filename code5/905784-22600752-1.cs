    List<string> stringList = new List<string>() { "0.14", "223.54" };
    List<decimal> list = stringList.Select(Convert.ToDecimal).ToList();
    
    MessageBox.Show(list[0].ToString(CultureInfo.InvariantCulture));
    MessageBox.Show(list[0].ToString(new CultureInfo("en-US")));
    MessageBox.Show(list[0].ToString(new CultureInfo("id-ID")));
