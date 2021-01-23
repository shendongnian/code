      public static bool VerifyPermission(FeatureValue feature, PermissionValue permission, int id) {
          return getFeaturePermissionsForReport(feature, permission, id);
      }
      private static bool getFeaturePermissionsForReport(FeatureValue feature, PermissionValue permission, int id) {
          SessionHelper sessionHelper = new SessionHelper(null);
          UserModel userModel = sessionHelper .getUser()//get user from session.
          if (userModel != null && userModel.IsAuthorized == false) return false;
          UserProfile userProfile = sessionHelper.Get<UserProfile> ();
          if (userProfile != null && userProfile.AssignedRoleList != null) {
              List<Core.Entities.FeaturePermission> featurePermission = userProfile.AssignedRoleList.SelectMany(b => b.RoleFeaturePermission).ToList();
         
              if (featurePermission != null) {
                  if (featurePermission.Count(f = > f.Feature.Id == (int) feature && f.Permission.Id == (int) permission) > 0) {
                      bool isAllowed= false;
                      int featurePermissionId = featurePermission.Where(f = > f.Feature.Id == (int) feature && f.Permission.Id == (int) permission).Select(i = > i.Id).FirstOrDefault();
                      isAllowed = (reports.Count(r = > (r.FeaturePermissionId == featurePermissionId && r.Id == id)) > 0) ? true : false;
                      return isAllowed;
                  }
              }
          }
          return false;
      }
