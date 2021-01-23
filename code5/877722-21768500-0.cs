    for (int i = 1; i <= numberOfRolls; i++)
    {
        int number = randomNumber();
        myNumberDictionary[number] += 1;
    
        foreach (var point in MyChart.Series["MySeries"].Points)
        {
                var startNew = Task.Factory.StartNew(() =>
                 {
                     Invoke(new Action(() =>
                       point.SetValueXY(Convert.ToInt32(point.XValue),
                       myNumberDictionary[Convert.ToInt32(point.XValue)]);
                 });
        }
    }
