    #External class 
    namespace DefNamespace
    {
	public class ModelList
	{
		private static List<GameObject> models;
		private ModelList ()
		{
		}
		public static List<GameObject> Models{
			get{
				if(models == null) models= new List<GameObject>();
				return models;
			}set{
				models=value;
			}
		}
	}
    }
