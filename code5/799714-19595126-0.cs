        [Test]
        public void TimeSpan_PmAmFormat()
        {
            TimeSpan timeSpan = new TimeSpan(23, 20, 0);
            DateTime dateTime = DateTime.MinValue.Add(timeSpan);
            CultureInfo cultureInfo = CultureInfo.InvariantCulture;
            // optional
            //CultureInfo cultureInfo = new CultureInfo(CultureInfo.CurrentCulture.Name);
            //cultureInfo.DateTimeFormat.PMDesignator = "PM";
            string result = dateTime.ToString("hh:mm tt", cultureInfo);
            Assert.True(result.StartsWith("11:20 PM"));
        }
