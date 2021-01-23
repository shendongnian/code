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
			var idsToDelete = new StringBuilder();
			foreach (var id in ids)
			{
				idsToDelete.AppendFormat(",{0}", id);
			}
			//ONLY because the parameter comes from a list of Int, else you might risk injection
			Database.ExecuteSqlCommand(string.Format("DELETE FROM CampainContacts WHERE CampaignId in ({0})", idsToDelete.ToString().Remove(0, 1)));
		}
		public void UpdateBatchCampaignContacts(int campaignId, IList<int> ids)
		{
			if (ids == null) return;
			if (ids.Count == 0) return;
			var idsToUpdate = new StringBuilder();
			foreach (var id in ids)
			{
				idsToUpdate.AppendFormat(",{0}", id);
			}
			Database.ExecuteSqlCommand(string.Format("UPDATE CampaignContacts SET CampaignId = @campaignId WHERE EmailContactId in ({0})", idsToUpdate.ToString().Remove(0, 1),
				new SqlParameter("@campaignId", campaignId)));
		}
	}
