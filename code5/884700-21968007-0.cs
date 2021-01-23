    // generic item. It has a description and can be traded
    public interface IItem {
        string Description { get; }
        float Cost { get; }
    }
    
    // potions, fruits etc., they have effects such as
    // +10 health, -5 fatigue and so on
    public interface IConsumableItem: IItem {
        void ApplyEffect(Character p);
    }
    
    // tools like hammers, sticks, swords ect., they can
    // be used on anything the player clicks on
    public interface IToolItem: IItem {
        void Use(Entity e);
    }    
This will make your code easier and more structured than using enums to discriminate between different items. And if you still need to do that, you can take advantage of the [is][1] operator and the method [IEnumerable.OfType<T>][2]. So here's what you can do:
    public class HealthPotion: IConsumableItem {
        public string Description {
            get { return "An apple you picked from a tree. It makes you feel better."; }
        }
        
        public float Cost {
            get { return 5f; }
        }
        
        public void ApplyEffect(Character p) {
            p.Health += 1;
        }
    }
    
    public class Player: Character {
        public List<IItem> Inventory { get; private set; }
        private IEnumerable<IConsumableItem> _consumables {
            get { return this.Inventory.OfType<IConsumableItem>(); }
        }
        public void InventoryItemSelected(IItem i) {
            if(IItem is IConsumableItem) {
                (IItem as IConsumableItem).ApplyEffect(this);
            }
            else if(IItem is IToolItem) {
                // ask the player to click on something
            }
            else if /* ...... */
            this.Inventory.Remove(i);
        }
    }
