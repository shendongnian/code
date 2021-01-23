    public void AddOrRemoveTags(IList<string> tags, Question question)
    {
       var dbQuestion = _context.Questions.Include(a => a.Tags).SingleOrDefault(a => a.QuestionId == question.QuestionId);
    	
       if (dbQuestion != null)
       {
          var remainingTags = new List<string>(tags);
          var tagsToRemove = dbQuestion.Tags.Where(t => !tags.Contains(t.Text, StringComparer.OrdinalIgnoreCase)).ToList();
          foreach (var tag in tagsToRemove)
          {
             dbQuestion.Tags.Remove(tag);
             remainingTags.remove(tag.Text);
          }
          foreach(var remainingTag in remainingTags){
             dbQuestion.Tags.Add(new Tag(){ Text = remainingTag });
          }
          _context.SaveChanges();
    		       
       }
    }
