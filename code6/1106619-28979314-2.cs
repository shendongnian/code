        static void Main(string[] args)
        {
            ImageService.ImageServiceClient client = new ImageService.ImageServiceClient();
            string data = client.GetData(@"C:\Users\v-sridve\Pictures\Travel_Error_New.PNG");
        }
