    //--------------- In your domain library:
    public class DataRepository : IDataRepository {
        
        public DataRepository() {
        } // end constructor
        public DataEntity GetData(DataRequest request) {
            //get data based on DataRequest
            return new DataEntity();
        } // end function GetData
    } // end class DataRepository
    public class DataRequest {
        
        public String RequestingUser {get; set;}
        public Dictionary<String, object> Parameters {get;}
    } // end class DataRequest
    public class DataEntity {
        public string Name {get; set;}
        public Guid Id {get; set;}
        public string SomeData {get; set;}
    } // end class DataEntity
    //--------------- In your web library:
    public class UserRequest {
        public string UserName {get; set;}
    } // end class UserRequest
    public class LandingPageViewModel {
        public LandingPageViewModel() {
            Data = new DataItemViewModel();
        } // end constructor
        public void FillData(DataEntity entity) {
             Data.Name = entity.Name;
             Data.DataValue = entity.SomeValue;
             Data.ShowValue = !String.IsNullOrWhiteSpace(UserName);
        } // end method FillData
        public string UserName {get; set;}
        public List<string> Messages {get; set;}
        
        public DataItemViewModel Data {get; set;}
    } // end class LandingPageViewModel
    public class DataItemViewModel {
        
        public string Name {get; set;}
        public string DataValue {get; set;}
        public bool ShowValue {get; set;}
    } // end class DataItemViewModel
    public class MyController : Controller {
        private IDataRepository _repository;
        public MyController(IDataRepository repository) {
            _repository = repository;
        } // end constructor
        
        public ActionResult LandingPage(UserRequest user) {
            ActionResult result = null;
            DataRequest itemRequest = new DataRequest();
            itemRequest.RequestingUser = user.UserName;
            DataEntity myEntity = null;
            myEntity = _repository.GetData(itemRequest);
            if(myEntity != null) {
               LandingPageViewModel viewModel = new LandingPageViewModel();
               viewModel.UserName = user.UserName;
               viewModel.FillData(myEntity);
               result = View("LandingPage", viewModel);
            } else {
               result = View("Error");
            } // end if/else
            return result;
        } // end action LandingPage
    } // end class MyController
    // In a view
    <%@ Page Title="" Language="VB" MasterPageFile="~/Views/Site.Master" Inherits="System.Web.Mvc.ViewPage(Of LandingPageViewModel)" %>
    <div>
        <%:Model.Name;%>
        <%
            if(Model.ShowValue) {
        %>
            <%:Model.DataValue;%>
        <%
            } // end if
        %>
    </div>
