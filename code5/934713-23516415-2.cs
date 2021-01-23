    //this would be your console host class
    public class HostInterface
    {
    	string sHeaderString;
    	public static string HeaderString {
    		get { return sHeaderString; }
    		set { sHeaderString = value; }
	
	
       public void main()
       {
    	  //code to start the web service
      	  System.ServiceModel.ServiceHost myWebService = default(System.ServiceModel.ServiceHost);
    	  //configure myWebService stuff
    	  myWebService.open();
    	  // here loop every second until the communication is stopped
          //check for new text in the shared sHeaderString 
          //written to by your web service class
          while (true) {
    		if (myWebService.state != Communicationsstate.Opened){
    			break; 
            }
    		//write message out through console
            console.writeline("Headers:" + sHeaderString);
    		Threading.Thread.Sleep(1000);
    		//sleep 1 second before going trying next
    	  }
        }
      }
    }
