     public string CelsiusTemp
            {
                get { return string.Format("{0}°C", _CelsiusTemp); }
                set
                {
                    value = value.Replace("°C", "");
                  _CelsiusTemp = value;
                }
            }
