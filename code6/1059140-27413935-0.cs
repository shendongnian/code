     public partial class DeleteCharacters : System.Web.UI.Page
    {
    	protected void Page_Load(object sender, EventArgs e)
    	{
    
    	}
    	private MarvelModelContext context = new MarvelModelContext();
    
    	protected void btnDeleteId_Click(object sender, EventArgs e)
    	{
    		int id = System.Convert.ToInt32(txtId.Text);
    		string Sname = SNameT.Text;
    		Character CRead = context.Character.FirstOrDefault(c => c.CharacterId == id && c.Superhero == Sname);
    		
    		if(CRead != null) // added this condition
    		{
    			context.Character.Remove(CRead);
    
    			context.SaveChanges();
    
    			//Clear Feilds
    			txtId.Text = "";
    			SNameT.Text = "";
    		}
    	}
    }
