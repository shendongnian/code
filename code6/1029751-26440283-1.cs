    float price;
    if(!Single.TryParse(Regex.Replace(tempPrice, "\D+$", ""), out price)) {
      price = 0;
    }
    // if it doesn't enter the condition, then price will have the parsed float value.
