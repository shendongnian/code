    void SearchPeers()
     {
         List<string> name = new List<string>();
         var peers = await PeerFinder.FindAllPeersAsync();
         for(int i=0;i<peers.Count;i++)
         {
	       string peerName = peers.DisplayName;
	       name.Add(peerName);
         }
     }
