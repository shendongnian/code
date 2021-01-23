	public partial interface IEquippable {
		EquippableTypes Type {
			get;
		}
	}
	public partial class Weapons: IEquippable {
		public EquippableTypes Type {
			get {
				return EquippableTypes.Weapons;
			}
		}
	}
	public partial class Shield: IEquippable {
		public EquippableTypes Type {
			get {
				return EquippableTypes.Shield;
			}
		}
	}
	public partial class Antenna: IEquippable {
		public EquippableTypes Type {
			get {
				return EquippableTypes.Antenna;
			}
		}
	}
	public partial class Underwear: IEquippable {
		public EquippableTypes Type {
			get {
				return EquippableTypes.Underwear;
			}
		}
	}
