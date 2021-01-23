    var message = new PayPal.IPNMessage(new Dictionary<string, string>()
                {
                    { "account1.apiUsername", config.APIUsername },
                    { "account1.apiPassword", config.APIPassword },
                    { "account1.apiSignature", config.APISignature },
                    { "mode", config.IsLiveMode ? "live" : "sandbox" }
                }, bytes);
