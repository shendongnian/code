	abstract class SettingsItem
	{
		public string Key {get;}
	}
	class SettingsItem<T> : SettingsItem {
	
	    public T Value {get;}
	}
	
	abstract class SettingsContainer {
	    public abstract void Set<T>(T item) where T : SettingsItem;
	    public abstract T Get<T> (string key) where T : SettingsItem;
	}
