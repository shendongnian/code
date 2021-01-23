    private void Button_Click(object sender, RoutedEventArgs e)
    {
        string[] array = new string[List2.Items.Count];
        for (int i = 0; i < List2.Items.Count; i++)
        {
            object s = List2.Items[i];
            array[i] = s.ToString();
        }
        TJSONObject jObject = new TJSONObject();
        TJSONPair jPair = new TJSONPair("test", array[0]);
        TJSONPair jPair1 = new TJSONPair("test1", "test1");
        TJSONArray jArray = new TJSONArray();
        jObject.addPairs(jPair);
        jObject.addPairs(jPair1);
        jArray.add(jObject);
        MessageBox.Show(jArray.ToString());
    }
