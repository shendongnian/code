    if ((e.Result.Text == "set a alarm") || (e.Result.Text == "set an alarm"))
            {
                Jarvis.Speak("setting alarm");
                string HourAlarmStr = HourAlarmCB.SelectedItem.ToString();
                label2.Content = DateTime.Today.Hour.ToString(HourAlarmStr) + ":" + DateTime.Today.Minute.ToString("54") + ":" + DateTime.Today.Second.ToString("00");
                label2.Opacity = 100;
                dispatcherTimer2.Start();
            }
