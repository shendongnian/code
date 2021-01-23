    var responses = GetResponsesFromDb();
    DateTime lastestStart = DateTime.MinValue;
    DateTime earliestEnd = DateTime.MaxValue;
    foreach (Response response in responses) {
      if (response.StartDateTime > lastestStart) {
        lastestStart = response.StartDateTime;
      }
      if (response.EndDateTime < earliestEnd) {
        earliestEnd = response.EndDateTime;
      }
    }
