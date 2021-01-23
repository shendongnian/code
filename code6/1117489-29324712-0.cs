	private async Task<bool> GetLicenseStatus(string id)
    {
		try
		{
			var result = await   CurrentApp.GetProductReceiptAsync(id);
		}
		catch //user didnt buy
		{
				return false;
		}
		return true;
	}
