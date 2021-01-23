    using(AppEntities ae = new AppEntities()){
        var slot = ae.AppointmentSlots.Single(m => m.AppointmentSlotID == firstAppointmentSlotID);
        slot.ReturnAppointmentSlotID = returnAppointmentSlotID;
        ae.ObjectStateManager.ChangeObjectState(slot, EntityState.Modified);
        ae.SaveChanges();
    }
