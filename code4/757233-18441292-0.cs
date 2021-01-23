    public JsonResult MyAPI()
    {
    
        return Json(new RootObject { api_version = 1,
                                     hotel_ids = 12342,
                                     hotels = new Hotel{ hotel_id = 123,
                                                         room_types = new RoomTypes...
                                           }
                                       }
    }
