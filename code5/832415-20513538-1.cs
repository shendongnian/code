      for (int i = 0; i < items.Length; ++i) {
        if (i % 2 == 0) { // <- Field Name
          String field = items[i];
          ...
        }
        else { // <- Value
          DateTime value = DateTime.Parse(items[i]); // <- Some kind of parsing; see also ParseExact, TryParse
          ...
        }
      }
