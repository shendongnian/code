        foreach (var item in searchList.resources)
        { 
                //First convert all questionIds to a string collection
                IEnumerable<String> allQuestionIDs = item.associatedQuestions.Select(q => q.id.ToString());
                //Convert array to single comma seperated String
                string questionIdsString = String.Join(", ", allQuestionIDs);
                myList.Add(new SelectListItem { Text = item.linktext.ToString(), Value = questionIdsString });
        }
        return System.Web.Helpers.Json.Encode(myList); 
    }
