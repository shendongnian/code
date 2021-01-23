        public Controller(IApiService service)
        {
            // Do one thing for each response
            service.Responses
                .Subscribe(responseHandler);
            // Do something else for each response
            service.Responses
                .Subscribe(r => _throttle.OnNext(0));
        }
