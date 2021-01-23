        public static void DisplayFreeBusy(
            string freeBusyString, DateTime start, int intervalLength)
        {
            TimeZoneInfo cst = TimeZoneInfo.FindSystemTimeZoneById("Central Standard Time");
            Collection<DateTime> duplicateSlots = 
                GetDuplicateSlots(cst, start, intervalLength, freeBusyString.Length);
            int duplicatesConsumed = 0;
            for (int slot = 0; slot < freeBusyString.Length; slot++)
            {
                int actualSlot = slot - duplicatesConsumed;
                DateTime slotTime = start.Date.AddMinutes(actualSlot * intervalLength);
                if (duplicatesConsumed != duplicateSlots.Count && 
                    duplicateSlots.Contains(slotTime))
                {
                    duplicatesConsumed++;
                }
                else
                {
                    Console.WriteLine("{0} -- {1}", slotTime, freeBusyString[slot]);
                }
            }
        }
