    public class GlassItem
    {
    	public string LargeImagePath {get;set;}
    	public string ThumbnailPath {get;set;}
    	public string GlassName {get;set;}
    }
    
    protected List<GlassItem> GetGlassItems(Guid CurrentPage)
    {
    	var items = new List<GlassItem>();
    	
       using (MySqlConnection cn = new MySqlConnection(ConfigurationManager.ConnectionStrings["Sitefinity"].ToString()))
       {
           cn.Open();
    
           MySqlCommand cmd = new MySqlCommand("SELECT id, BrandID, GlassName, Thumbnail, LargeImage, Ordinal, (SELECT Window_Brands.BrandName FROM Window_Brands WHERE Window_Brands.BrandPage = BrandID) AS BrandName FROM Window_Brand_cutglass WHERE BrandID = ?PageID AND Thumbnail IS NOT NULL AND LargeImage IS NOT NULL ORDER BY Ordinal", cn);
           cmd.Parameters.Add(new MySqlParameter("PageID", CurrentPage.ToString()));
    
           using (MySqlDataReader reader = cmd.ExecuteReader())
           {
               while (reader.Read())
               {
                   if (reader["Thumbnail"].ToString().Length > 1 && reader["LargeImage"].ToString().Length > 1)
    				{
    				 	items.Add(new GlassItem 
    							{ 
    								LargeImagePath = Revere.GetImagePath(reader["LargeImage"].ToString()), 
    								ThumbnailPath = Revere.GetImagePath(reader["Thumbnail"].ToString()), 
    								GlassName = reader["GlassName"].ToString()
    							});
    				}	
               }
           }
    
           cn.Close();
       }
    
        return items;
    }
