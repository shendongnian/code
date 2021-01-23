        private NodeCollection activeClients(AdvTree tree)
        {
            NodeCollection activeClients = new NodeCollection();
            foreach (Node client in tree.Nodes)
            {
                if (client.IsVisible)
                {
                    //Add Visible Node to activeClients Node Array
                    activeClients.Add(client, eTreeAction.Code);
                }
            }
            return activeClients;
        }
