	[DataContract]
	public partial class ImprimanteSNData : IExtensibleDataObject
	{
		private ExtensionDataObject extensionDataObjectValue;
		public ExtensionDataObject ExtensionData
		{
			get { return this.extensionDataObjectValue; }
			set { this.extensionDataObjectValue = value; }
		}
		[DataMember(Order = 2)]
		public System.Boolean IsConnected
		{
			get 
			{
				return this.isConnected;
			}
			set 
			{
				this.isConnected = value;
			}
		}
		[DataMember(Order = 0)]
		public System.Collections.Generic.List<System.String> Printer
		{
			get 
			{
				return this.printer ?? new System.Collections.Generic.List<System.String>();
			}
			set 
			{
				this.printer = value;
			}
		}
		[DataMember(Order = 1)]
		public System.String SerialNumber
		{
			get 
			{
				return this.serialNumber == null ? String.Empty : this.serialNumber.Trim();
			}
			set 
			{
				this.serialNumber = value;
			}
		}
	}
