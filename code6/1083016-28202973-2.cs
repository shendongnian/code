    string textBox1 = "1 2 3 4 5 6 7 8 9 10";
    var numbersAsStrings = textBox1.Text.Split(' ');
    List<double> numbersAsDoubles = new List<double>();
    foreach (var numberAsString in numbersAsStrings)
    {
        double numberAsDouble;
        if (double.TryParse(numberAsString,out numberAsDouble))
        {
            numbersAsDoubles.Add(numberAsDouble);
        }
    }
    var min = numbersAsDoubles.Min();
    var max = numbersAsDoubles.Max();
    var outputMessage =  string.Format("min: {0} max: {1}", min, max);
    textBox2.Text = outputMessage;
