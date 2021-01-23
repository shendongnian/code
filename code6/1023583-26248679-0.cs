    struct DataInfo {
        public string Name,
        public string Value
    }
    var data = new List<DataInfo>();
    for(var x = 1; x < 10; x++) {
        var textBox = this.Find("textBox" + x);
        var button = this.Find("button" + x); // find the controls somehow
        data.Add(new DataInfo { Name = Convert.ToInt32(button.Text), Value = textBox.Text };
    }
    data.Sort((left, right) => left.Value.CompareTo(right.Value));
