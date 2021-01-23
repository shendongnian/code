    ...
            WebClientResponse webClientResponse;
            if (!string.IsNullOrWhiteSpace(ForceSecurityProtocol))
            {
                using (var isolated = new Isolated<WebClient>())
                {
                    webClientResponse = isolated.Value.GetResponse(url, ForceSecurityProtocol);
                }
            }
            else
            {
                webClientResponse = _webClient.GetResponse(url);
            }
    ...
