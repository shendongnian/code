    public void Processrequest(){
        Task.Factory.StartNew(() => {
            string request = Generaterequest();
            //access and process request here
        });
    }
