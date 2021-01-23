        [HttpPost]
        [CorsEnabled]
        [ActionName("upfile")]
        public DTO.Callback UploadPhoto()
        {
            var m = new Logic.Components.User();
            return m.UploadPhoto(HttpContext.Current.Request, Common.UserValues().Email);
        }
