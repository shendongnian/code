            [HttpPost]
            [ValidateAntiForgeryToken]
            public ActionResult Create(string appId, AppFeedback feedback)
            {
                feedback.CreatedDate = DateTime.Now;
                feedback.CreatedBy = HttpContext.User.Identity.Name;
    
                response = client.PostAsJsonAsync("api/appfeedback", feedback).Result;
                if (response.IsSuccessStatusCode)
                {
                    ViewBag.CustomMessage = "Thank you for submitting feedback!";
                    return View("Create", new AppFeedback() { AppId = appId });
                }
                else
                {
                    LoggerHelper.GetLogger().InsertError(new Exception(string.Format(
                        "Cannot create a new feedback record due to HTTP Response Status Code not being successful: {0}", response.StatusCode)));
                    return View("Problem");
                }
            }
