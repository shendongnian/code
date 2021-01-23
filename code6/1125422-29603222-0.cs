    public class Result
    {
        public int Stud_Id { get; set; }
        ...
        ...
        public string Notification { get; set; }
        public string[] Notifications { get; set; }
    }
    List<Result> result = from c in db.Class
        join s in db.Students on c.Cls_Id equals s.Cls_Id
        select new Result
        {
            Stud_Id = s.Stud_Id,
            ...
            ...
            Notification = c.Notification
        }).ToList();
    result.ForEach(r =>
        {
            r.Notifications = r.Notification.Split('/');
        });
