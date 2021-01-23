    Dictionary<DateTime, int> conductivityData = new Dictionary<DateTime, int>();
    // Get the y-values
    i=0;
    foreach (var entry in waterConductivityData[1])
                {
                    condData[i] = Convert.ToInt32(entry);
                    i++;
                }
    // Add the dates ("entry" from datelist) and the y-value (condData) to the dictionary
    i=0;
    foreach (var entry in parsedDateList[0])
                {
                        conductivityData.Add(entry, condData[i]);
                        i++;
                }
    //Add the data to the plot series using "key" for dates and "value" for y-data
    foreach (var entry in conductivityData)
                        {
                                filteredDateStrings[0].Add(entry.Key.ToString("M/d/yy hh:mm tt"));
                                filteredCondData[0].Add(entry.Value);
                        }
    // Update plot data
                    i = 0;
                    foreach (var entry in filteredCondData[0])
                    {
                        waterSourceTwoChart.Series["conductivity"].Points.AddXY(filteredDateStrings[0].ElementAt(i), filteredCondData[0].ElementAt(i));
                        i++;
                    }
   
