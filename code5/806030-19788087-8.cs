    	private void Button_Decrypt_Click(object sender, EventArgs e)
	{
		byte[] Key = DES_Class.StringToByteArray(TextBox_Encrypt_Key.Text);
		byte[] IV = DES_Class.StringToByteArray(TextBox_Encrypt_IV.Text);
		byte[] str = DES_Class.DecryptFileAndReturnStream(TextBox_Encrypt_OuputFilePath.Text,Key, IV);
		InitFlashMovie(str);
	}
	private void InitFlashMovie(byte[] swfFile)
	{
		using (MemoryStream stm = new MemoryStream())
		{
			using (BinaryWriter writer = new BinaryWriter(stm))
			{
				/* Write length of stream for AxHost.State */
				writer.Write(8 + swfFile.Length);
				/* Write Flash magic 'fUfU' */
				writer.Write(0x55665566);
				/* Length of swf file */
				writer.Write(swfFile.Length);
				writer.Write(swfFile);
				stm.Seek(0, SeekOrigin.Begin);
				/* 1 == IPeristStreamInit */
				AxShockwaveFlash1.OcxState = new AxHost.State(stm, 1, true, null);
			}
		}
	}
