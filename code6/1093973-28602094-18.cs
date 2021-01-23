        public Communicator(Context context)
        {
            client = new GoogleApiClientBuilder(context)
                .AddApi(WearableClass.Api)
                .Build();
        }
