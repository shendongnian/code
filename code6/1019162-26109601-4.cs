    public void AddTags(IList<string> tags, Question question)
    {    	
      if (question != null)
      {
        var existingTags = _context.Tags.Where(t => tags.ToArray().Contains(t.Text)).ToList()
        var remainingTags = new List<string>(tags);
        foreach (var tag in existingTags)
        {
          question.Tags.Add(tag);
          remainingTags.remove(tag.Text);
        }
        foreach(var remainingTag in remainingTags){
          question.Tags.Add(new Tag(){ Text = remainingTag });
        }
      }
    }
