	public static int Insert(Func<IfxConnection, IfxTransaction, object> processMethod, UserTransactionDTO transObj, string spPostConfirm, int toEmpNum, int confirmState)
	{
		int affectedRows = -7;
		using (IfxConnection conn = new IfxConnection(ConfigurationManager.ConnectionStrings["crms"].ToString() + " Enlist=true;"))
		{
			if (conn.State == ConnectionState.Closed)
			{
				conn.Open();
			}
			using (IfxTransaction tran = conn.BeginTransaction())
			{
				try
				{
					if (processMethod != null)//business Method
					{
						object res = processMethod(conn, tran);
						transObj.ValuesKey = res.ToString();
					}
					if (string.IsNullOrEmpty(transObj.ValuesKey)) //Fail
					{
						tran.Rollback();
						return -1;//Fail 
					}
					
					affectedRows = RunPreConfirm(transObj.TaskCode, transObj.UserStateCode, transObj.ValuesKey, conn, tran, confirmState);//sp_confirm
					if (affectedRows != 1)
					{
						tran.Rollback();
						return -1;//Fail
					}
					
					affectedRows = InsertTrans(transObj, conn, tran);//MainTransaction --->df2usertrans
					if (affectedRows != 1)//Fail
					{
						tran.Rollback();
						return -1;//Fail 
					}
					
					if (!string.IsNullOrEmpty(spPostConfirm))
					{
						affectedRows = RunPostConfirm(spPostConfirm, transObj.ValuesKey, conn, tran);//sp_post_confirm
						if (affectedRows != 0)
						{
							tran.Rollback();
							return -2;//Fail 
						}
					}
					affectedRows = RunAfterTrans(transObj.TaskCode, transObj.OldStatusCode, transObj, toEmpNum, conn, tran);//sp_after_trans
					if (affectedRows != 1)
					{
						tran.Rollback();
						return -3;//Fail
					}
					tran.Commit();
					return 1;
				}
				catch
				{
					trans.Rollback();
					throw;
				}
			}
		}
		return affectedRows;
	}
			
