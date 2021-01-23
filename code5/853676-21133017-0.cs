    void Main()
    {
    	var infoId = Guid.NewGuid();
    	var alertId = Guid.NewGuid();
    	
    	var info = new Info();
    	info.InfoId = infoId;
    	
    	var alert = new Alert();
    	alert.AlertId = alertId;
    	alert.Infos.Add(info);
    	
    	var jss = new JavaScriptSerializer();
    	
    	var json = jss.Serialize(alert); //JsonConvert.SerializeObject(alert);
    	Debug.WriteLine(json); //All looking good, nothing missing
    	
    	var deserializedObject = jss.Deserialize<Alert>(json); //JsonConvert.DeserializeObject<Alert>(json);
    	(alertId == deserializedObject.AlertId).Dump(); //Assert is valid
    	(infoId == deserializedObject.Infos[0].InfoId).Dump(); //Assert is valid
    	
    	var json2 = jss.Serialize(deserializedObject); //JsonConvert.SerializeObject(deserializedObject);
    	Debug.WriteLine(json2); //Infos is gone - NOT GONE!
    }
    	
    public class Alert
    {
    	public Guid AlertId { get; set; }
    	public List<Info> Infos { get; set; }
    	
    	public Alert()
    	{
    		Infos = new List<Info>();
    	}
    }
    
    public class Info
    {
    	public Guid InfoId { get; set; }
    }
