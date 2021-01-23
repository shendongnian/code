public class CompanyMap : EntityTypeConfiguration&ltCompany>
{
  public CompanyMap()
  {
    // Add this
    this.HasRequired(x => x.CreatedByProfile).WithMany().Map(
      x => x.MapKey("CreatedByProfileId"));
    
    // CreatedByProfileId is the FK column in the Company table that points
    // to the Profile table. This is my made up name for the column since
    // I don't know the real name in your database.
  }
}
