    public static void UpdateSlotCapacity(MagazineSlot slot)
        {
            using (var session = SessionManager.OpenSession())
            {
                session.Lock(slot, LockMode.Upgrade);
        
                if (slot.Card.CardClass.ClassId == CardClassId.ClassI ||
                    slot.Card.CardClass.ClassId == CardClassId.ClassB ||
                    slot.Card.CardClass.ClassId == CardClassId.ClassC ||
                    slot.Card.CardClass.ClassId == CardClassId.ClassE ||
                    slot.Card.CardClass.ClassId == CardClassId.ClassG)
                {
                    Dialogs.ShowInfo("Capacity update is not allowed for " + slot.Card.CardClass.ClassName + " cards");
                    return;
                }
            }
        }
