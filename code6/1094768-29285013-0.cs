    namespace MyProjectName
    {
        public partial class MyPage : System.Web.UI.Page
        {
            //This gets us access to the NHibernate Class Library
            IDATABASE DataBase = Microsoft.Practices.ServiceLocation.ServiceLocator.Current.GetInstance<IDATABASE>();
            protected void Page_Load(object sender, EventArgs e)
            {
                DataBase.Clear(); //clear the first-level cache in NHibernaet
                var EntityOneRaw = DataBase.EntityOne.ToList();
                var EntityOneObjects = EntityOneRaw.Select(q => AutoMapper.Mapper.Map<NHibernateClassLibrary.Entities.EntityOne, EntityOnePoco>(q)).ToList();
                GridViewObject.DataSource = new BindingList<EntityOnePoco>(EntityOneObjects);
                GridViewObject.DataBind();
            }
            protected void ButtonOne_Click(object sender, EventArgs e)
            {
                var Item = DataBase.EntityOne.First();
                Item.PropertyTwo = "New Value";
                DataBase.SaveChanges(); //NHibernate call to commit
            }
        }
    }
