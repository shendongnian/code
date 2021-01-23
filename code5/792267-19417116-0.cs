    Socket rtr = .. //ZMQ.ROUTER
    Socket pub = .. //ZMQ.PUB  
    ZMQ.Poller poller = new ZMQ.Poller(2)
    poller.register( rtr, ZMQ.Poller.POLLIN)                               
    poller.register( pub, ZMQ.Poller.POLLIN)
           
      while (true) {
         ZMsg msg = null            
         poller.poll(5000)
    
         if( poller.pollin(0)){
            //messages from crawlers                         
            msg = ZMsg.recvMsg(rtr)
         }
    
         //send heartbeat messages
         ZMsg hearbeatMsg = ...
         //create message content here,
         //publish to all crawlers
         heartbeatMsg.send(pub)
      }
