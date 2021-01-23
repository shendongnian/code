        public static void UpdateSchedule(int selectedScheduleId)
        {
            using (var dc = new MyDataContext())
            {
                UpdateScheduleWithDataContext(selectedScheduleId, dc);
            }
        }
