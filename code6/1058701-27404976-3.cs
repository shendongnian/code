        var events =
                  db.myEvents.Where(
                    e =>
                    e.date >= DateTime.Now
                    && ((!e.@private)
                        || (e.@private
                            && e.AspNetRoles.Where(a => a.AspNetUsers.Select(b => b.Id)
                                 .ToList()
                                 .Contains(userId))
                                 .Select(c => c.myEvents.Select(d => d.Id)
                                 .ToList()
                                 .Contains(e.Id))
                                 .Any())))
                    .Select(
                      e =>
                      new EventItem
                        {
                          id = e.Id,
                          date = e.date,
                          description = e.description,
                          privateE = e.@private,
                          title = e.title,
                          type = e.type,
                          url = e.url
                        });
    public class EventItem
    {
      public int id { get; set; }
      public DateTime? date { get; set; }
      public string description { get; set; }
      public string title { get; set; }
      public string type { get; set; }
      public string url { get; set; }
      public bool privateE { get; set; }
    }
