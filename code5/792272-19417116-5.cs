    Socket dlr = .. //ZMQ.DEALER
    Socket sub = .. //ZMQ.SUB
    ZMQ.Poller poller = new ZMQ.Poller(2)
    poller.register( dlr, ZMQ.Poller.POLLIN)                               
    poller.register( sub, ZMQ.Poller.POLLIN)
           
      while (true) {
         ZMsg msg = null            
         poller.poll(5000)
    
         if( poller.pollin(0)){
            //message from server                         
            msg = ZMsg.recvMsg(dlr)
         }
    
         if( poller.pollin(1)){
          //heartbeat message from server
           msg = ZMsg.recvMsg(sub)
           //reply back with status
           ZMsg statusMsg = ...
           statusMsg.send(dlr)
      }
