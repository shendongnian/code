    public ActionResult Index(
        string date
        , int? courseid = null
        , int? clubid = null
        , int? holes = null
        , int? available = null
        , int? prices = null
    )
    {
        var DateFrom = DateTime.ParseExact(date, "yyyy-MM-dd", CultureInfo.InvariantCulture);
        MTeetimes r = BookingManager.GetBookings(new Code.Classes.Params.ParamGetBooking()
        {
            ClubID = clubid
            , DateFrom = DateFrom
            , DateTo = DateFrom.AddDays(1)
            , GroundID = courseid
        });
        // return Json(r, JsonRequestBehavior.AllowGet);
        string response;
        var serializer = new DataContractJsonSerializer(typeof(MTeetimes));
        // Serialize
        using (var ms = new MemoryStream())
        {
            serializer.WriteObject(ms, r);
            response = Encoding.Default.GetString(ms.ToArray());
        }
        return Content(response);
    }
