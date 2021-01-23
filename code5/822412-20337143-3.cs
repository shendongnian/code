     public string Post(ProfilePictureRequest profilePictureRequest) // your request DTO
            {
                var user = _userRepository.GetByEmail(this.GetSession().Email);
                foreach (var uploadedFile in RequestContext.Files)
                {
                    using (var fileStream = new MemoryStream())
                    {
                      // save changes to your database
                      // save file to disk       
    
                    }
                return user.ProfilePicture;
            }
