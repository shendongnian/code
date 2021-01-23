		/// <summary>
		/// Enables the phone radio on device
		/// </summary>
		public void EnablePhoneRadio()
		{
				SetDeviceState(RADIODEVTYPE.RADIODEVICES_PHONE, RADIODEVSTATE.RADIODEVICES_ON);
		}
