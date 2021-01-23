	public partial class DemoPage : System.Web.UI.Page
	{
		protected string GetPriorityName(object priority)
		{
			switch ((int)priority)
			{
				case 1:
					return "Critical";
				case 2:
					return "High Priority";
				case 3:
					return "Low Priority";
				case 4:
					return "General";
				default:
					return "Unknown";
			}
		}
	}
