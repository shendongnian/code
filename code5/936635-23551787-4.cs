    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.SqlClient;
    using System.Text;
    public class YourDbContext : DbContext
	{
		public void DeleteBatchCampaignContacts(IList<int> ids)
		{
			if (ids == null) return;
			if (ids.Count == 0) return;			
			//ONLY because the parameter comes from a list of Int, else you might risk injection
			Database.ExecuteSqlCommand(string.Format("DELETE FROM CampainContacts WHERE CampaignId in ({0})", string.Join(",", ids)));
		}
		public void UpdateBatchCampaignContacts(int campaignId, IList<int> ids)
		{
			if (ids == null) return;
			if (ids.Count == 0) return;
			Database.ExecuteSqlCommand(string.Format("UPDATE CampaignContacts SET CampaignId = @campaignId WHERE EmailContactId in ({0})", string.Join(",", ids),
				new SqlParameter("@campaignId", campaignId)));
		}
	}
