      if (!String.IsNullOrEmpty(modify))
      {
              Dictionary<int, string> indexAndNewItem = new Dictionary<int, string>();
          foreach (string item in tcomboBox1.Items)
          {
              bool contains = Regex.IsMatch(modify, @"\b" + item + "\b");
              if (contains == true)
              {
                  string theItem = "$" + item + "$";
                  modify = modify.Replace(item, theItem);
                  indexAndNewItem.Add(tcomboBox1.Items.IndexOf(item),modify);
              }
          }
          foreach (var keyValue in indexAndNewItem)
          {
              tcomboBox1.Items[keyValue.Key] = keyValue.Value;
          }
          //ttextBox1.Text = modify;
          modify = "";
