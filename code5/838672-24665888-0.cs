			var sourceContext = new InstanceContext(sourceObject);
			var sourceFactory = new DuplexChannelFactory<TChannel>(sourceContext, endpointName);
			
			TChannel sourceProxy = sourceFactory.CreateChannel();
			var remoteOnlyFilter = new RemoteOnlyMessagePropagationFilter();
			var peerNode = ((IClientChannel)sourceProxy).GetProperty<PeerNode>();
			peerNode.MessagePropagationFilter = remoteOnlyFilter;
			try
			{
				sourceProxy.Open();
			}
			catch (Exception)
			{
				sourceProxy.TryCloseOrAbort();
				throw;
			}
