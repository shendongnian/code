    ShowMessage("Loading"); // Running on UI thread
            Task.Factory.StartNew(() =>
            {
                try
                {
                    return DataContext.DatabaseExists();
                }
                catch (SqlException)
                {
                    return false;
                }
            }).ContinueWith(isValid =>
            {
                if (isValid.Result)
                    ShowMessage("Success");
                else
                    ShowMessage("Failure");
            });
