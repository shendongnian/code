			get { return notification.CallRequest.Id; }
		}
		public string RowClass
		{
			get
			{
				return overduePolicy.IsOverdue() ? "overdue" : "";
			}
		}
		public string SearchCssClass
		{
			get
			{
				return notification.CallRequest.IsVoided ? "voided" : "";
			}
		}
