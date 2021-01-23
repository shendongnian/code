            FieldUserValue [] fTo = oListItem["People picker field name"]  as FieldUserValue[];
                var userTo = clientContext.Web.SiteUsers.GetById(fTo[0].LookupId);
                clientContext.Load(userTo);
                clientContext.ExecuteQuery();
                headers.To.Add(userTo.Email);
