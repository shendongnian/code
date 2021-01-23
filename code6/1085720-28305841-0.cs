    SPWeb web = SPContext.Current.Web;
                        web.AllowUnsafeUpdates = true;
                        web.AllProperties["ButtonClick"] = "ButtonHasBeenCliked";
                        web.IndexedPropertyKeys.Add("ButtonClick");
                        web.Update();
                        web.AllowUnsafeUpdates = false;
