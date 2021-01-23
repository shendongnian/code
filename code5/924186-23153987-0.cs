                foreach (DataPoint point in charts.Points)
                {
                    if (point.AxisLabel == LibereStr)
                    {
                        point.Color = Color.Green;
                        point.Font = new Font("Trebuchet MS", 9, FontStyle.Bold);
                        if (Libere == 0)
                        {
                            point.IsEmpty = true;
                        }
                    }
                    else if (point.AxisLabel == OccupateStr)
                    {
                        point.Color = Color.Red;
                        point.Font = new Font("Trebuchet MS", 9, FontStyle.Bold);
                        if (Occupate == 0)
                        {
                            point.IsEmpty = true;
                        }
                    }
                    else if (point.AxisLabel == PrenotateStr)
                    {
                        point.Color = Color.Violet;
                        point.Font = new Font("Trebuchet MS", 9, FontStyle.Bold);
                        if (Prenotate == 0)
                        {
                            point.IsEmpty = true;
                        }
                    }
                    point.Label = string.Format("{0:0} - {1}", point.YValues[0], point.AxisLabel);
                }
            } 
