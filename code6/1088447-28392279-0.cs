    public static IQueryable<ProfileInfo> ToProfileInfo(this IQueryable<TB_Res_Profile> query)
    {
      return query.Select(x => new ProfileInfo()
      {
        ProfileID= dbProfile.ProfileID,
        FullName = dbProfile.FullName, 
        Headline = dbProfile.Headline,
        Location = dbProfile.Location,
        Industry = dbProfile.Industry,
        ImageUrl = dbProfile.ImageUrl,
        EducationInstitute = dbProfile.EducationInstitute,
        Degree = dbProfile.Degree
      });
    }
