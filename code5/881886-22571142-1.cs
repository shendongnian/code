        protected override void OnError(EventArgs e) {
            var err = Server.GetLastError().GetBaseException();
            var errorMessage = String.Format("URL {0}: {1} Error: {2}", Request.Url, err.GetType(), err.Message);
            ((MyMasterPageClass)Master).ShowError(errorMessage);
            Server.ClearError();            
        }
