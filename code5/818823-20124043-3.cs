public class OrganisationMap : EntityTypeConfiguration&ltOrganisation>
{
    public OrganisationMap()
    {
        HasOptional(n => n.Parent)
            .WithMany(n => n.Children)
            .Map(m => m.MapKey("ParentId"));
        Ignore(n => n.Ancestors);
    }
}
