    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            ddlBind();
        }
    }
    
    public class Medical
    {
        public int MedicalID { get; set; }
        public string MedicalName { get; set; }
        public int CityFK { get; set; }
    }
    
    public class City
    {
        public int CityID { get; set; }
        public string CityName { get; set; }
    }
    
    protected void ddlBind()
    {
        var medicals = new List<Medical>()
        {
            new Medical {MedicalID = 1, MedicalName = "One", CityFK = 11},
            new Medical {MedicalID = 2, MedicalName = "Two", CityFK = 22},
            new Medical {MedicalID = 3, MedicalName = "Three", CityFK = 33},
            new Medical {MedicalID = 4, MedicalName = "Four", CityFK = 44},
        };
    
        ddlMedicalName.DataSource = medicals;
        ddlMedicalName.DataTextField = "medicalname";
        ddlMedicalName.DataValueField = "cityfk";
    
        ddlMedicalName.DataBind();
    
    }
    
    protected void ddlMedicalName_OnSelectedIndexChanged(object sender, EventArgs e)
    {
        var cities = new List<City>()
        {
            new City {CityID = 11, CityName = "City One"},
            new City {CityID = 22, CityName = "City Two"},
            new City {CityID = 33, CityName = "City Three"},
            new City {CityID = 44, CityName = "City Four"},
        };
    
        int slc = Convert.ToInt32(ddlMedicalName.SelectedItem.Value);
    
        var orders = from order in cities
                        where order.CityID == slc
                        select new { order.CityID, order.CityName };
    
        var lstsrc = orders.ToList();
    
        ddlCity.DataSource = lstsrc;
        ddlCity.DataTextField = "CityName";
        ddlCity.DataValueField = "CityID";
    
        ddlCity.DataBind();
    }
    
    protected void ddlRegion_SelectedIndexChanged(object sender, EventArgs e)
    {
    
    }
    
    protected void ddlCity_SelectedIndexChanged(object sender, EventArgs e)
    {
    
    }
    
    protected void SearchButton_Click(object sender, EventArgs e)
    {
    
    }
