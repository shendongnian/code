    public MergeIntoLargerSlots(List<DateTime> slots, int minutes)
    {
         int count = minutes/30;
         List<DateTime> retVal = new List<DateTime>();
         foreach (DateTime slot in slots)
         {
              DateTime end = slot.AddMinutes(minutes);
              if (slots.Where(x >= slot && x < end).Count() == count)
              {
                  retVal.Add(slot);
              }
         }
         return retVal;   
    }
