        string categoryId = "";
        string questionID = "";
        foreach (var item in searchList.resources)
        { 
                //First convert all questionIds to a string array
                string[] allQuestionIDs = item.associatedQuestions.Select(q => q.id.ToString())).ToArray();
                //Convert array to single comma seperated String
                string questionIdsString = String.Join(", ", allQuestionIDs);
                myList.Add(new SelectListItem { Text = item.linktext.ToString(), Value = questionIdsString });
        }
        return System.Web.Helpers.Json.Encode(myList); 
    }
