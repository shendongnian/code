			public class Common
			{
			  public int? Data
			  {
				 get
				 {
					if(Session["Data"]!=null)
					{
						return  int.Parse(Session["Data"].ToString());
					}
					return null.
				 }
				 set
				 {
				   Session["Data"]=value;
				 }
			  }
			}
