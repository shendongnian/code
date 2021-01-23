      public class TimeSlot
      {
         // some fields temporarily removed 
         public DateTime TimeSlotFrom { get; set; }
         public DateTime TimeSlotTo { get; set; }
         public TimeSlot()
         {
            // some fields temporarily removed 
            this.TimeSlotFrom = DateTime.Now.Date;
            this.TimeSlotTo = DateTime.Now.Date;
         }
         /// <summary>
         /// Method to move the end date forward one day if the start and end dates are the same and 
         /// the end time is less than the start time, for example start hour = 7 and end hour = 4.
         /// </summary>
         public void AdjustEndDateIfNecessary()
         {
            if (TimeSlotFrom.Date == TimeSlotTo.Date &&
                TimeSlotFrom.Hour > TimeSlotTo.Hour)
            {
               TimeSlotTo = TimeSlotTo.AddDays(1);
            }
         }
         /// <summary>
         /// Method to move the whole time slot (both start and end time) by incrementing by one day.
         /// </summary>
         public void IncrementTimeSlotByOneDay()
         {
            TimeSlotFrom = TimeSlotFrom.AddDays(1);
            TimeSlotTo = TimeSlotTo.AddDays(1);
         }
      }
      /// <summary>
      /// Method to go through a List{} of TimeSlot objects and do two things:
      /// - "normalize" them by fixing the end date if it is wrong
      /// - push time slots into the future if they overlap with the previous time slot. (This has a 
      /// cascading effect, so the last time slot may end up several days in the future.)
      /// </summary>
      private void CheckFixDateInList(List<TimeSlot> timeSlots)
      {
         DateTime highestEndTimeSoFar = DateTime.MinValue;
         foreach (TimeSlot timeSlot in timeSlots)
         {
            timeSlot.AdjustEndDateIfNecessary();
            while (timeSlot.TimeSlotFrom < highestEndTimeSoFar)
            {
               timeSlot.IncrementTimeSlotByOneDay();
            }
            highestEndTimeSoFar = timeSlot.TimeSlotTo;
         }
      }
