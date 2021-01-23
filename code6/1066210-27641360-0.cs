    class ClientServiceClass : ClientBase<ITheServiceContract>, ITheServiceContract
    {
		public ClientServiceClass ( string endpointConfigurationName ) :
			base( endpointConfigurationName )
		{
		}
        internal void uploadFile(RemoteFileInfo request)
        {
            Channel.uploadFile(request);
        }
    }
