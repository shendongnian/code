    public class CustomDialog
    {
        public async Task<CustomType> Select()
        {
            return await Task.Run(
                () =>
                {
                    //operation
                    Thread.Sleep(400);
                    return new CustomType {code = 5};
                });
        }
    }
