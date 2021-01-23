    JArray aAllValues = JArray.Parse(json);
    var SampleObjectCollection = new List<SampleObject>();
    foreach (JArray aValues in aAllValues)
    {
        var oSampleObject = new SampleObject();
        int index = 0;
        foreach (var oProperty in aValues.Children())
        {
            switch (index)
            {
                case 0:
                    oSampleObject.Letter = oProperty.Value<String>();
                    break;
                case 1:
                    oSampleObject.FirstNumber = oProperty.Value<String>();
                    break;
                case 2:
                    oSampleObject.SecondNumber = oProperty.Value<String>();
                    break;
            }
            index++;
        }
        SampleObjectCollection.Add(oSampleObject);
    }
