    public class SQLHelper
    {
    
    	public IList<Person> GetPersons()
    	{
    	try
    		{
    			var result = new List<Person>();
    			conn = new MySqlConnection(connstring);
    			conn.Open();
    			MySqlCommand myCommand = new MySqlCommand("SELECT * FROM person", conn);
    			MySqlDataReader myReader;
    			myReader = myCommand.ExecuteReader();
    			while (myReader.Read())
    			{
    				result.add(new Person(){ID = myReader["personID"], ...});
    			}
    			return result;
    		}
    		catch
    		{
    			return null;
    		}
    	}	
    
    }
    
    public class Person
    {
    	public string ID {get;set;}
    	public string FirstName {get;set;}
    	public string LastName {get;set;}
    	public string Address {get;set;}
    	public string PhoneNumber {get;set;}
    	public string PostCode {get;set;}
    	public string DateOfBirth {get;set;}
    	
    	public override string ToString()
    	{
    		return ID + " | " + FirstName + " | " + "...";
    	}
    }
    
    private void fillcomboBox()
    {
    	cmbTable.Items.Clear();
    	var sqlHelper = new SQLHelper();
    	var persons = sqlHelper.GetPersons();
    	if(persons == null)
    	{
    		lblInfo.Text = " Error reading the database.";
    		return;
    	}
    	foreach(var person in persons)
    	{
    		cmbTable.Items.Add(person.ToString());
    	}
    }
