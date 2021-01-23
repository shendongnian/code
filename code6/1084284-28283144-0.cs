    static List<Note> GetCustomerNotes()
    {
      Customer c = new Customer();
      c.Notes = new List<Note>();
      foreach (Note note in notes)
        c.Notes.Add(note);
      return c.Notes;
    }
