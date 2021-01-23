        public ActionResult Register(string id)
        {
            var model = new RegisterViewModel();
            if (!string.IsNullOrWhiteSpace(id) && id.ToLower() == "professional")
            {
                model.IsProfessional = true;
            }
            else
            {
                model.IsProfessional = false;
            }
            return View();
        }
