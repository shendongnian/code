    public ActionResult Signup()
        {
            //The cookie could be stored in the format: partnumber_databaseid
            //An example cookie would look like 1_24
            if (request.Cookies["SingupProgress"] != null)
            {
                var part = request.Cookies["SignupProgress"].ToString().Split('_')[0];
                var id = request.Cookies["SignupProgress"].ToString().Split('_')[1];
                //Eg if the cookie stored number "1" as part, the returned view would be "Part2"
                //Return the stored part number plus one, as the part number will represent which part they have already completed
                string ViewName = "Part" + part + 1;
                return View(ViewName);
            }
            else
            {
                //If the cookie doesn't exist, that means the user has not made any sign up progress
                //Direct them to the first signup part
                return View("Part1");
            }
        }
        public ActionResult Part2()
        {
            //Direct the user to this action once they have clicked next on the Part 1 view
            //Create the class to store the progress data.
            //You also need this to extract the Unique ID for the cookie
            ProgressClass Progress = new ProgressClass(/*Your data*/);
            //Store the progress into the database
            db.StoreProgressData();
            db.Save();
            //Get the unique ID that you just saved into the database
            int Id = Progress.Id;
            HttpCookie ProgressCookie = new HttpCookie("SignupProgress", Id + "_2");
        }
        //Once they reach part 3 your final link can direct them to a register action, which creates the account and saves it to a database
