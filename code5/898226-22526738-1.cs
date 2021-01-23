            [HttpPost]
            public void EditCard(IList<CardModel> cm, IEnumerable<HttpPostedFileBase> files)
            {
                string strfile = string.Empty;
                string cardTitle = string.Empty;
                if (files != null)
                {
                    foreach (var file in files) //loop through to get posted file
                    {
                        strfile = file.FileName;
                    }
                }
                if (cm != null)
                {
                    foreach (var item in cm) //loop through to get CardModel fields
                    {
                        cardTitle = item.CardTitle;
                    }
                }
            }
