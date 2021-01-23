    public ActionResult Bid(int itemid, decimal bidAmount)
        {
            Item item = db.Items.Find(itemid);
            if (item.EndDate < DateTime.Now)
            {
                // Too late, the auction is over
                return View("AuctionComplete");
            }
            if (bidAmount > item.Bids.OrderByDescending(b => b.Value).First().Value);
            {
                // Valid bid, add to db and return view
                db.Bids.Add(new Bid() { ItemID = itemid, Value = bidAmount });
                db.SaveChanges();
                return View();
            }
            // There is a higher bid than this one already
            return View("Outbid");
        }
