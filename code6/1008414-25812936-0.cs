            private void InvokeWebMethod(Action webMethod, string username = null, string password = null)
            {
               using (OperationContextScope contextScope = new OperationContextScope(presenceServer.InnerChannel))
                {
                    var bc = Encoding.UTF8.GetBytes(string.Format(@"{0}:{1}", username ?? this.Username, password ?? this.Password));
                    HttpRequestMessageProperty httpProps = new HttpRequestMessageProperty();
                    httpProps.Headers[HttpRequestHeader.Authorization] = "Basic " + Convert.ToBase64String(bc);
    
                    OperationContext.Current.OutgoingMessageProperties[HttpRequestMessageProperty.Name] = httpProps;
                    webMethod();
                }
            }
