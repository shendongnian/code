    public Node LeaderIs(List<Node> list)
    {
        Node Leadernode = null;
        int LeadernodeDensity = 0;
        for (int k = 0; k < list.Count; k++)
        {
            var i = YelloWPages.GetNode(k, list);
            int iDensity = Node.GetDensity(i); 
            if ( iDensity > LeadernodeDensity)
            {
                Leadernode = i;
                LeadernodeDensity = iDensity;
            }
        }
        return Leadernode;
    }
