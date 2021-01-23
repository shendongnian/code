    using Apps4KidsWeb.Domain;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web;
    
    namespace Apps4KidsWeb.Models
    {
        public class EditedAppRepository
        {
            #region singleton
    
            private static EditedAppRepository singleton;
    
            public static EditedAppRepository GetInstance()
            {
                if (singleton == null)
                {
                    singleton = new EditedAppRepository();                
                }
                return singleton;
            }
    
            private EditedAppRepository()
            {
                this.repository = new Dictionary<string, AddAppViewModel>();
            }
    
            #endregion
    
            #region fields
    
            private Dictionary<string, AddAppViewModel> repository;
    
            #endregion
    
            #region methods
    
            public AddAppViewModel CreateNewApp(IApp app)
            {
                string guid = Guid.NewGuid().ToString();
                AddAppViewModel result = new AddAppViewModel(app) { Guid = guid };
                repository.Add(guid, result);
                result.Saved += OnAppSaved;
                return result;
            }
    
            public AddAppViewModel CreateNewApp(IRecommendationEx recommendation) 
            {
                string guid = Guid.NewGuid().ToString();
                AddAppViewModel result = new AddAppViewModel(recommendation) { Guid = guid };
                repository.Add(guid, result);
                result.Saved += OnAppSaved;
                return result;
            }
    
            public AddAppViewModel CreateNewApp()
            {
                string guid = Guid.NewGuid().ToString();
                AddAppViewModel result = new AddAppViewModel() { Guid=guid  };
                repository.Add(guid, result);
                result.Saved += OnAppSaved;
                return result;
            }
    
            public AddAppViewModel GetApp(string guid)
            {
                if (guid != null && repository.ContainsKey(guid))
                {
                    return repository[guid];
                }
                return null;
            }
    
            private void OnAppSaved(object sender, EventArgs e)
            {
                AddAppViewModel model = (AddAppViewModel)sender;
                repository.Remove(model.Guid);
            }
    
            public byte[] GetAppPicture(string guid, int id)
            {
                return repository[guid].Images[id];
            }
    
            #endregion
        }
    }
