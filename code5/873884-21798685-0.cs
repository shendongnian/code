    [Serializable]
    public class ItemList:MonoBehaviour {
    	[SerializeField] private List<ItemEquipable> equipableItems = new     List<ItemEquipable>();
	    [SerializeField] private List<ItemWeapon> weaponItems = new List<ItemWeapon>();
	    [SerializeField] private List<ItemPower> powerItems = new List<ItemPower>();
	    [SerializeField] private List<ItemSpecial> specialItems = new List<ItemSpecial>();
	    public List<ItemEquipable> EquipableItems { get { return equipableItems; } }
	    public List<ItemWeapon> WeaponItems { get { return weaponItems; } }
	    public List<ItemPower> PowerItems { get { return powerItems; } }
	    public List<ItemSpecial> SpecialItems { get { return specialItems; } }
    }
