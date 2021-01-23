    namespace ExceptionHandlingTestConsole
    {
    	class Program
    	{
    		static void Main(string[] args)
    		{
    			try
    			{
    				Console.WriteLine("do something");
				throw new System.Web.Services.Protocols.SoapException();
				//throw new Exception("my exception", new Exception("my inner exception"));
			}
			catch (System.Web.Services.Protocols.SoapException soapEx)
			{
				Console.Write("Detail: ");
				Console.WriteLine(soapEx.Detail);
				Console.Write("Node: ");
				Console.WriteLine(soapEx.Node);
				Console.Write("Role: ");
				Console.WriteLine(soapEx.Role);
				Console.Write("Message: ");
				Console.WriteLine(soapEx.Message);
			}
    			catch (Exception ex)
    			{
    				Console.WriteLine(ex.Message);
    				if (ex.InnerException != null)
    				{
    					Console.WriteLine("inner exception msg: " + ex.InnerException.Message);
    				}
    			}
    			Console.ReadKey();
    		}
    
    	}
    }
