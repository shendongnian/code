                var r = new Object()
                //define binding 
                //assume your binding using basicHttp, change it if you are using something else
                BasicHttpBinding myBinding = new BasicHttpBinding();           
    
                //define endpoint url              
                EndpointAddress myEndpoint = new EndpointAddress("http://localhost:11234/HHservice.svc"); //change to real endpoint 
    
                //Use channle factory instead of generated one
                ChannelFactory<IHHservice> myChannelFactory = new ChannelFactory<IHHservice>(myBinding, myEndpoint); //Change to you WCF interface
                IHHservice HHservice= myChannelFactory.CreateChannel();
    
                //and call it            
                var result = HHservice.PostProperty(r); //input to your method
    
                ((IClientChannel)HHservice).Close();
                myChannelFactory.Close();
