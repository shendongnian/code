            public Stream GetStaticData()
            {
                var objTobeReturned = something;
                WebOperationContext.Current.OutgoingResponse.ContentType = "application/json; charset=utf-8";
                return new MemoryStream(Encoding.UTF8.GetBytes(objTobeReturned.ToJson()));
            }
