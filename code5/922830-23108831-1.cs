    [Authorize]
    [HttpPost]
        public ActionResult CreateComment(FormCollection form)
        {
            string commentContents = form["commentContents"].ToString();
            int Id = Convert.ToInt32(form["Id"]);
            BO.CommentItem commentItem = new BO.CommentItem(
                Id,
                commentContents,
                (int)Membership.GetUser().ProviderUserKey);
    
            using (DataLayer.Repository db = new DataLayer.Repository())
            {
                db.AddComment(commentItem);
                db.Save();
            }
    
            return View();
    
        }
