    public class DropdownDisplay
    {
    	public DropdownDisplay(EntityType1 ent1, EntityType2 ent2)
    	{
    		value = ent1.Cursusdata_ID.ToString();
    		Text = String.Format(
    			"{0}-{1}-{2}-{3}",
    			ent2.Cursus_Code,
    			ent1.Cursusdata_startdatum == null ? string.Empty : ((DateTime)ent1.Cursusdata_startdatum).ToShortDateString(),
    			ent1.Cursusdata_einddatum == null ? string.Empty : ((DateTime)ent1.Cursusdata_einddatum).ToShortDateString(),
    			ent1.Cursusdata_tijden_NL
    		);
    	}
    	public string value { get; set; }
    	public string Text { get; set; }
    }
