    while (secondreader.Read()) {
      var myReadValue = secondreader.GetValue(1).ToString();
      if (dictionary.ContainsKey(myReadValue)) {
        if(dictionary[myReadValue] != null) {
          dictionary[myReadValue].Value2 = secondreader.GetValue(2).ToString();
        }
      }
    }
