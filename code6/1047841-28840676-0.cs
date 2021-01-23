            public void run() {
            connections = new ConnectionInfo[]{
                new ConnectionInfo(1, 0, "149.154.167.40", 443)
            };
            apiState = new ApiState(connections);
            doReqCode(connections);
            private void doReqCode(connections){
                        
            var args = new SocketAsyncEventArgs();
