        [TestMethod]
        public void TestMethod1()
        {
            Action test = () =>
                {
                    var dailyAlarm = new DailyAlarm(DateTime.Now.AddSeconds(5.0));
                    dailyAlarm.DailyAlarmEvent += dailyAlarm_DailyAlarmEvent;
                    dailyAlarm.Start();
                };
            DispatcherHelper.ExecuteOnDispatcherThread(test, 20);
        }
        void dailyAlarm_DailyAlarmEvent(EventArgs e)
        {
            // event invoked when DispatcherTimer expires
        }
