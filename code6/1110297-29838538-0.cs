        class RpcResponseResultConverter : JsonCreationConverter<RpcResponseResult>
        {
            protected override RpcResponseResult Create(Type objectType, JObject jObject)
            {
                // determine extended responses
                if (FieldExists("hostName", jObject) &&
                    FieldExists("hostPort", jObject) )
                {
                    return new RpcExtendedResponseResult();
                }
                //default
                return new RpcResponseResult();
            }
        }
