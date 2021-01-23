        private static void TestFreeSlots()
        {
            var saving = TimeZone.CurrentTimeZone.GetDaylightChanges(DateTime.Now.Year);
            var datetime = new DateTime(saving.End.Year, saving.End.Month, saving.End.Day - 1);
            //you may need to change the string to see effective result
            var result = ParseFreeBusy("0000000000000000000000000000000000000000000000002222000", datetime);
        }
