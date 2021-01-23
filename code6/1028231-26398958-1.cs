    SerializationModel serializationModel = new SerializationModel
              {
                  Data = new Data
                  {
                      Gender = "mALE",
                      Id = "88",
                      Name = "User",
                      Picture = new Picture
                      {
                          Data = new PictureData
                          {
                              is_silhouette = true,
                              url = "www.google.com"
                          }
                      }
                  }
              };
            string serializedString = Newtonsoft.Json.JsonConvert.SerializeObject(serializationModel);
