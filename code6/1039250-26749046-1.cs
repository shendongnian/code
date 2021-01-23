    using System;
    using System.IO;
    using System.Web.UI.WebControls;
    using System.Xml.Serialization;
    
    namespace ReadXMLData
    {
        public partial class ShowPeople : System.Web.UI.Page
        {
            protected void Page_Load(object sender, EventArgs e)
            {
                if (!IsPostBack)
                {
                    LoadDataFromXML();
                }
            }
    
            private void LoadDataFromXML()
            {
                // Loads XML data from an external XML file
                XmlSerializer deserializer = new XmlSerializer(typeof(People));
                TextReader textReader = new StreamReader(@"D:\Temp\People.xml");
    
                People PeopleList = new People();
                PeopleList = (People)deserializer.Deserialize(textReader);
                textReader.Close();
    
                gvPeople.DataSource = PeopleList;
                gvPeople.DataBind();
            }
    
            protected void gvPeople_PageIndexChanging(object sender, GridViewPageEventArgs e)
            {
                // GridView paging 
                gvPeople.PageIndex = e.NewPageIndex;
                LoadDataFromXML();
            }
        }
    }
