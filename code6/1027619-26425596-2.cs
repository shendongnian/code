                var response = JsonObject.Parse(responseData).ConvertTo(x => new GetRoomListResponse()
                {
                    Acknowledge = (AcknowledgeType)x.Get<int>("Acknowledge"),
                    Code = x.Get<int>("Code"),
                    Exception = x.Get("Exception"),
                    Message = x.Get("Message"),
                    RoomList = x.ArrayObjects("RoomList").ConvertAll<RoomModel>(y => new RoomModel()
                    {
                        Id = y.Get<Guid>("Id"),
                        Description = y.Get("Description"),
                        Location = y.Object("Location").ConvertTo<LocationModel>(z => new LocationModel()
                        {
                            Id = z.Get<Guid>("Id"),
                            Code = z.Get("Code"),
                            Description = z.Get("Description"),
                            Number = z.Get<int>("Number"),
                        }),
                    }),
                });
