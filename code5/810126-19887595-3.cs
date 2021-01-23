    private void button1_Click(object sender, EventArgs e)
            {
                ServiceReference1.RCommServiceClient service = new ServiceReference1.RCommServiceClient();
                CustomRequest customRequest=new CustomRequest();
                customRequest.MyValue = 10;
    
                Result result = service.SendMessage("Test", customRequest);
            }
