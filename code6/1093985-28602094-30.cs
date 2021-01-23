        IList<INode> Nodes()
        {
            var result = WearableClass.NodeApi.GetConnectedNodes(client).Await();
            return result.JavaCast<INodeApiGetConnectedNodesResult>().Nodes;
        }
