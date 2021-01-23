    public ActionResult Index()
    {
       List<CardFileModel> cards = new List<CardFileModel>
       {
           new CardFileModel{ CardId =1 , Name="Card1"  },
           new CardFileModel{ CardId =2 , Name="Card2"  }
       };
       return View(cards);
    }
