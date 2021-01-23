     var startTime = 9;
                var endTime = 16;
                var slot = 10;
    
                var time = new DateTime(2000, 1, 1, startTime , 0, 0);
                var timeCollectionForAM = new List<string>();
                var timeCollectionForPM = new List<string>();
                for (int i = startTime; i < endTime; i++)
                {
                    
                    for (int y = 0; y < 6; y++)
                    {
                        if (time.ToString("tt") == "AM")
                        {
                            timeCollectionForAM.Add(time.ToString("t") + " - " + time.AddMinutes(slot).ToString("t"));
                        }
                        else {
                            timeCollectionForPM.Add(time.ToString("t") + " - " + time.AddMinutes(slot).ToString("t"));
                        }
                        
                        time = time.AddMinutes(slot);
                    }
    
                }
