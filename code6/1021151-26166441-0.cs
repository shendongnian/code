        private void CheckFixDateinList(List<TimeSlot> lstTimeSlots)
        {
            Boolean bHourChanged = false;
            int Fromlasthour = 0;
            int Tolasthour = 0;
            foreach(TimeSlot UEP in lstTimeSlots)
            {
                if (UEP.TimeSlotFrom.Hour < Fromlasthour)
                    bHourChanged = true;
                if (bHourChanged)
                    UEP.TimeSlotFrom = UEP.TimeSlotFrom.AddDays(1);
                
                Fromlasthour = UEP.TimeSlotFrom.Hour;
                
                if (bHourChanged )
                  UEP.TimeSlotTo = UEP.TimeSlotTo.AddDays(1);
                if (UEP.TimeSlotTo < UEP.TimeSlotFrom)
                {
                    bHourChanged = true;
                    UEP.TimeSlotTo = UEP.TimeSlotTo.AddDays(1);
                }
            }
        }
