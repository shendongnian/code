    [HttpPost]
        public JsonResult doesURLExist(tPost post)
        {
            var allposts = _unitOfWork.PostRepository.Get();
            if (allposts.Count(p => p.URLString == post.URLString) == 0)
            {
                return Json(true, JsonRequestBehavior.AllowGet);
            }
            if (allposts.Count(p => p.URLString == post.URLString && p.Id == post.Id) == 1)
            {
                return Json(true, JsonRequestBehavior.AllowGet);
            }
           
            return Json(false, JsonRequestBehavior.AllowGet);
        }
