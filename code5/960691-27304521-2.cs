		/// <summary>
		/// Disables the phone radio on device
		/// </summary>
		public void DisablePhoneRadio()
		{
				SetDeviceState(RADIODEVTYPE.RADIODEVICES_PHONE, RADIODEVSTATE.RADIODEVICES_OFF);
		}
