        /// <summary>
        /// Make a call to the service
        /// </summary>
        /// <param name="action"></param>
        /// <param name="endpoint"> </param>
        public async Task<ResultCallWrapper<TResult>> CallAsync<TResult>(Func<T, Task<TResult>> action, EndpointAddress endpoint)
        {
            using (ChannelLifetime<T> channelLifetime = new ChannelLifetime<T>(ConstructChannel(endpoint)))
            {
                // OperationContextScope doesn't work with async/await
                var oldContext = OperationContext.Current;
                OperationContext.Current = new OperationContext((IContextChannel)channelLifetime.Channel);
                var result = await action(channelLifetime.Channel)
                    .WithOperationContext(configureAwait: false);
                HttpResponseMessageProperty incomingMessageProperty = (HttpResponseMessageProperty)OperationContext.Current.IncomingMessageProperties[HttpResponseMessageProperty.Name];
                string[] keys = incomingMessageProperty.Headers.AllKeys;
                var headersOrig = keys.ToDictionary(t => t, t => incomingMessageProperty.Headers[t]);
                OperationContext.Current = oldContext;
                return new ResultCallWrapper<TResult>(result, new ReadOnlyDictionary<string, string>(headersOrig));
            }
        }
