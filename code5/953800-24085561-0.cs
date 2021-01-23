            degress.TempConvert todegress = new degress.TempConvert();
            wetther.Weather wether = new wetther.Weather();
            wetther.WeatherReturn f = wether.GetCityWeatherByZIP("10001");
            string city = f.City;
            bool correct = f.Success;
            string farenhait = f.Temperature;
