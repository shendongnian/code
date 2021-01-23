     [ServiceContract]
    //[ServiceBehavior(InstanceContextMode = InstanceContextMode.PerCall)]
    public interface IService1
    {    
        /// <summary>
        /// An asynchronous service side upload operation.
        /// </summary>
        /// <param name="token">An application arbitrary piece of data.  Can be used for request obfuscation.</param>
        /// <param name="data">The data being uploaded.</param>
        /// <param name="callback">Callback for async pattern, client does not pass this.</param>
        /// <param name="asyncState">User state for async pattern, client does not pass this.</param>
        /// <remarks>
        /// The <paramref name="token"/> parameter is the only parameter passed in the URL by the client.  The <paramref name="data"/>
        /// parameter is the request body, the file being uploaded.
        /// </remarks>
        /// <returns></returns>
        [OperationContract(AsyncPattern = true)]
        [WebInvoke(Method = "PUT", UriTemplate = "asyncupload/")]
        IAsyncResult BeginAsyncUpload(Stream data, AsyncCallback callback, object asyncState);
        /// <summary>
        /// Ends the asynchonous operation initiated by the call to <see cref="BeginAsyncUpload"/>.
        /// </summary>
        /// <remarks>
        /// This is called by the WCF framework service side.  NOTE:  There is no <see cref="OperationContractAttribute"/> decorating
        /// this method.
        /// </remarks>
        /// <param name="ar"></param>
        void EndAsyncUpload(IAsyncResult ar);
    }
