    public ActionResult Membership()
    {
         var memberDetails = MemberDetails.GetMembershipDetails(userid);
         var memberLevel = memberDetails.MemberLevel;
         switch (memberLevel)
         {
             default:
             case 0:
                 return View("Basic", memberDetails);
             case 1:
                 return View("Gold", memberDetails);
             case 2:
                 return View("Platinum", memberDetails);
         }
    }
