    public static class FlurlXmlExtensions
        {
            /// <summary>
            /// Sends an asynchronous POST request that contains an XML string.
            /// </summary>
            /// <param name="client">The IFlurlClient instance.</param>
            /// <param name="data">Contents of the request body.</param>
            /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation. Optional.</param>
            /// <param name="completionOption">The HttpCompletionOption used in the request. Optional.</param>
            /// <returns>A Task whose result is the received HttpResponseMessage.</returns>
            public static Task<HttpResponseMessage> PostXmlStringAsync(this IFlurlClient client, string data, CancellationToken cancellationToken = default(CancellationToken), HttpCompletionOption completionOption = HttpCompletionOption.ResponseContentRead)
            {
                var content = new CapturedStringContent(data, Encoding.UTF8, "text/xml");
    
                return client.SendAsync(HttpMethod.Post, content: content, cancellationToken: cancellationToken, completionOption: completionOption);
            }
    
        }
