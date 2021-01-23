    private class City {
        public int value { get; set; }
        public string text { get; set; }
    }
    
    // ...
    
    return Json(new City[] { new City { value = 1, text = "Amsterdam" } }, JsonRequestBehavior.AllowGet);
