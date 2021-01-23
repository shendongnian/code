    public void TopTenHighScore() {
        int sessionCounter = 0;
        ParseQuery<ParseObject> query = ParseObject.GetQuery("Runs").WhereEqualTo("scoreIdentifier", GameController.instance.scoreContext).OrderByDescending("score");
        query.Include("session.user");
        query.FindAsync().ContinueWith(t => {
            IEnumerable<ParseObject> results = t.Result;
            foreach (var item in results) {
                if (item.ContainsKey("score")) {
                    if (sessionCounter < 10) {
                        // --- this is for the overall Score
                        topTenScores[sessionCounter] = item.Get<int>("score"); 
                      
                        ParseObject sessionPointer = item.Get<ParseObject>("session");
                        Task<ParseObject> session = sessionPointer.FetchAsync<ParseObject>();  
                      
                        session.ContinueWith(tt => {
                            ParseObject userPointer = tt.Result;                            
                           Task<ParseObject> user = userPointer.Get<ParseObject>("user").FetchAsync<ParseObject>();
                           user.ContinueWith(ttt => {
                               ParseObject userFinal = ttt.Result;
                               userNamesList.Add(userFinal.Get<string>("displayName"));
                           });
                        });
                    }
                    if (sessionCounter == 9) {
                        sessionCounterDone = true;
                    }
                    sessionCounter++;
                }
                // if the amount of sessions played in total is not above 10
                if (sessionCounter < 10)
                    sessionCounterDone = true;
            }
        });
    }
