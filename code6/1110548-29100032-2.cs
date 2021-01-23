        public interface IMySql
    	{
    		void Connect();
    	}
    	class RemoteMySQL : IMySql
    	{
    		public void Connect()
    		{}
    	}
    
    	class MySQL : IMySql
    	{
    		public void Connect()
    		{ }
    	}
