    [HttpGet]
    public List<SomeEntity> Get(){
            var gotResult = false;
            List<SomeEntity> result;
            var task = new Task(() =>
            {
                result = SomeWhere.GetDataSlow();
                gotResult = true;
            });
            while (!gotResult)
            {
                if (!Response.IsClientConnected)
                {
                    task.Dispose();
                    return result;
                }
                Thread.Sleep(100);
            }
            return result;
    }
