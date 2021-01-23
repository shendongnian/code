        public static void LoadMeeting<T>(this T entity, IMeetingRepository meetingRepository) where T: MyEntity {
            var name = entity.GetType().Name;
            if (Table.ContainsKey(name)) {
                Table[name](entity, meetingRepository);
                }
            }
