    public class EquipmentNeedingService : List<Equipment>
    {
        // no internal list is need: public readonly List<Equipment> ...();
        // no need to any AddEquipmentToList(), but if you insist:
        public void AddEquipmentToList(Equipment equipment)
        {
            this.Add(equipment);
        }
    }
