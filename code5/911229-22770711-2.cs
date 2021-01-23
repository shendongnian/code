    private void CheckForGaps(List<DisplayBookingDetails> list)
    {
        DateTime endPrevious;
        DateTime startCurrent;
        int minBookingLength = 60;
        DisplayBookingDetails nullMarker = null;
        DateTime dayStart = new DateTime(0001, 01, 01).AddHours(09)
        DateTime dayEnd = new DateTime(0001, 01, 01).AddHours(21)
        List<DisplayBookingDetails> testList = new List<DisplayBookingDetails>();
        if (list.Length > 0) // First we check if the list has any items
        {
            DateTime startTime = dayStart;
            DateTime endTime = list[0].StartTime;
            // Fill the gap before the first appointment with blank appointments
            while ((endTime - startTime).TotalMinutes >= minBookingLength)
            {
                nullMarker = new DisplayBookingDetails(0) { Start = startTime.ToShortTimeString(), End = startTime.AddMinutes(minBookingLength).ToShortTimeString() };
                testList.Add(nullMarker);
                startTime = startTime.AddMinutes(minBookingLength);
            }
            // Go through the appointments adding them
            for (int i = 1; i < list.Length; i++)
            {
                testList.Add(list[i - 1]);
                endPrevious = list[i - 1].EndTime;
                startCurrent = list[i].StartTime;
                startTime = endPrevious;
                // Fill gaps between appointments
                while ((startCurrent - startTime).TotalMinutes >= minBookingLength)
                {
                    nullMarker = new DisplayBookingDetails(0) { Start = startTime.ToShortTimeString(), End = startTime.AddMinutes(minBookingLength).ToShortTimeString() };
                    testList.Add(nullMarker);
                    startTime = startTime.AddMinutes(minBookingLength);
                }
            }
            // Add the last appointment
            testList.Add(list[list.Length - 1]);
            // Add blank appointments after the last appointment until End of Day
            startTime = list[list.Length - 1].EndTime;
            while ((dayEnd - startTime).TotalMinutes >= minBookingLength)
            {
                nullMarker = new DisplayBookingDetails(0) { Start = startTime.ToShortTimeString(), End = startTime.AddMinutes(minBookingLength).ToShortTimeString() };
                testList.Add(nullMarker);
                startTime = startTime.AddMinutes(minBookingLength);
            }
        }
        else // No items in list, add all blank appointments
        {
            DateTime startTime = dayStart;
            while((dayEnd - startTime).TotalMinutes >= minBookingLength)
            {
                nullMarker = new DisplayBookingDetails(0) { Start = startTime.ToShortTimeString(), End = startTime.AddMinutes(minBookingLength).ToShortTimeString() };
                testList.Add(nullMarker);
                startTime = startTime.AddMinutes(minBookingLength);
            }
        }
        // Display the final list
        DisplayBookingDetails = testList;
    }
