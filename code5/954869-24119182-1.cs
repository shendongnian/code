    public class RegistryEditor
	{
		RegistryKey m_key;
		public RegistryEditor()
		{
			m_key = Registry.CurrentUser.OpenSubKey("Software\\Company name", true);
			m_key = m_key.CreateSubKey("Product name", RegistryKeyPermissionCheck.ReadWriteSubTree);
		}
		public string GetValue(string name)
		{
			return m_key.GetValue(name, "").ToString();
		}
		public void SetValue(string name, string value)
		{
			m_key.SetValue(name, value, RegistryValueKind.String);
		}
	}
