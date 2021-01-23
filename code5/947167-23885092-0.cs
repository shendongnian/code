    [DelimitedRecord(",")]
    public class SanctionOFACEntries
    {
    	public int ent_num
    	[FieldQuoted]
    	public string ent_num { get; set; }
    	[FieldQuoted]
    	public string SDN_Name { get; set; }
    	[FieldQuoted]
    	public string SDN_Type { get; set; }
    	[FieldQuoted]
    	public string Program { get; set; }
    	[FieldQuoted]
    	public string Title { get; set; }
    	[FieldQuoted]
    	public string Call_Sign { get; set; }
    	[FieldQuoted]
    	public string Vess_type { get; set; }
    	[FieldQuoted]
    	public string Tonnage { get; set; }
    	[FieldQuoted]
    	public string GRT { get; set; }
    	[FieldQuoted]
    	public string Vess_flag { get; set; }
    	[FieldQuoted]
    	public string Vess_owner { get; set; }
    	[FieldQuoted]
    	public string Remarks { get; set; }
    }
