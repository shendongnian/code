    public class InvertorySlots
    {
        private Player _Player;
     
        public InventorySlots(Player player)
        { 
        }
    
        public InventoryItem[] GetItems()
        {
            return new InventoryItem[] { 
                  _Player.EqiupAmulet,  
                  _Player.EqiupArmor,  
                  _Player.EqiupBelt,  
                  _Player.EqiupBoots,  
                  _Player.EqiupCloak,  
                  _Player.EqiupArmor,  
                  _Player.EqiupGauntlets,  
                  _Player.EqiupHelmet };
        }
    }
