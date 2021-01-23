      string st = "1234785";
      int i = 0;
      int counter = 0;
      st.All(x => {
      if (char.IsDigit(x))
       {
          i += (int)(char.GetNumericValue(x) * Math.Pow(10, (st.Length - counter - 1)));
       }
      counter++;
      return true;
    });
