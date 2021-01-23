        public ActionResult Create()
        {
            var transaction = new Transaction
            {
                User = new UserProfile
                {
                    Details = new UserDetails()
                }
            };
            return View(transaction);
        }
