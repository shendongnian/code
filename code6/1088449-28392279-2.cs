    public static IQueryable<ProfileInfo> ToProfileInfo(this IQueryable<TB_Res_Profile> query)
    {
      return query.Select(p => new ProfileInfo()
      {
        ProfileID= p.ProfileID,
        FullName = p.FullName, 
        Headline = p.Headline,
        Location = p.Location,
        Industry = p.Industry,
        ImageUrl = p.ImageUrl,
        EducationInstitute = p.EducationInstitute,
        Degree = p.Degree
      });
    }
