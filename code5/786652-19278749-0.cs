                RestClient Edit = new RestClient("https://api.quizlet.com");
                RestRequest EditRequest = new RestRequest();
                foreach (var i in ID) 
                { 
                    EditRequest.AddParameter("term_ids[]", i);
                } 
                foreach (var i in Terms)
                {
                    EditRequest.AddParameter("terms[]", i);
                }
                foreach(var i in Definitions)
                {
                    EditRequest.AddParameter("definitions[]", i);
                }
                EditRequest.AddParameter("title", item.Title);
                EditRequest.AddHeader("Authorization", "Bearer " + CurrentLogin.AccessToken);
                EditRequest.AddHeader("Host", "api.quizlet.com");
                EditRequest.Resource = "2.0/sets/" + item.Id;
                EditRequest.Method= Method.PUT;
                Edit.ExecuteAsync(EditRequest, Response =>
                {
                    FinalizeUpdate(Response);
                });
