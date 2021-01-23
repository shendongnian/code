           switch (response.currently.icon.ToString())
            {
                case ("clear-day"):
                    //do something
                    MorningTime.Attributes.Add("class", "sun");
                    MorningType.Attributes.Add("class", "sun");
                    DayTime.Attributes.Add("class", "sun");
                    DayType.Attributes.Add("class", "sun");
                    break;
                case ("partly-cloudy-day"):
                    //do something
                    MorningTime.Attributes.Add("class", "sun");
                    MorningType.Attributes.Add("class", "cloud windy");
                    DayTime.Attributes.Add("class", "sun");
                    DayType.Attributes.Add("class", "cloud windy");
                    EveningTime.Attributes.Add("class", "sun");
                    EveningType.Attributes.Add("class", "cloud windy");
                    NightTime.Attributes.Add("class", "moon");
                    NightType.Attributes.Add("class", "cloud windy");
                    break;
                case ("rain"):
