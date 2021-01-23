	[WebMethod]
	public long NextCall(long UserID)
	{
		CampaignManagerExtended cacheCampaignManager = fillCampaignManager(false);
		return cacheCampaignManager.NextCall(UserID).First();
	}
	public IEnumerable<long> NextCall(long UserID)
	{
		int returnID;
		UserExtended ue = null;
		
		try
		{
			if (!CacheUsers.ContainsKey(UserID))
			{
				AddUser(UserID);
			}
			ue = CacheUsers.First(p => p.Key == UserID).Value;
			
			if (ue.NextCampaign != null)
			{
				QueueItemPersonal qp = ue.NextFromPersonalQueue();
				
				if (qp != null)
				{
					returnID =  qp.CampaignPersonID;
				}
				else 
				{ 
					QueueItemScheduled qs = ue.NextCampaign.NextFromScheduleQueue();
					
					if (qs != null)
					{
						returnID  = qs.CampaignPersonID;
					}
					else 
					{ 
						QueueItemGeneral qg = ue.NextCampaign.NextFromGeneralQueue();
						
						if (qg != null)
						{
							returnID = qg.CampaignPersonID;
						}                  
						else
						{
							 returnID = 0;
						}
					}
				}
				
				ue.NextCampaign.fillGeneralQueue();
				ue.setNextCampaign();
			}
			else
			{
				returnID = 0;
			}
			
			yield return returnID;
		}
		//catch
		//{
		//    yield return 0;
		//}
		finally
		{
		}
	}
