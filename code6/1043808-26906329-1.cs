        public DTO.Callback UploadPhoto(HttpRequest req, string email)
        {
            if (req.Files.Count > 0)
            {
                var file = req.Files[0];
                var m = new Logic.Components.User();
                return m.UploadPhoto(file.InputStream, email);
            }
            return new DTO.Callback { Message = "Fail to upload. Make sure that you are uploading an image file." };
        }
