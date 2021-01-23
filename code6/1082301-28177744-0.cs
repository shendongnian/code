       public abstract void ActOn(Player player);
    }
    public class EquipAction : Action 
    {
        private Item item;
        public EquipCommand(Item item) {
          this.item = item;
        }
        public void ActOn(Player player) {
           player.Equipment.Add(item);
        }
    } 
    public interface IPlayer
    {
        void PerformAction(Action action);
    }
    public class EquipmentSet
    {
        public List<Item> Items { get; private set;}
    } 
    public class EquipmentManager
    {
        public Add(Item item) {
        }
        public List<Item> Items { get; }
    }
    public class Player : IPlayer
    {
        public EquipmentManager manager;
        public PerformAction(Action action) {
           action.ActOn(this);
        }
        public List<Items> Equipment {
           return manager.Items;
        }
    }
