    public class CustomEmails
    {
        private string _basePath = null;
        private string BasePath 
        {
            get 
            {
                 if ( _basePath == null ) 
                 {
                     this._basePath = Server.MapPath('...');  
                 }
                 return _basePath;
            }
        }
 
