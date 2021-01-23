    public class MemberController : ControllerBase<Member>
    {
        public override void InsertOrUpdate(Member obj)
        {
            using (var context = new ChocDB())
            {
                var state = context.Entry(obj).State = obj.Id == 0
                                                  ? EntityState.Added
                                                  : EntityState.Modified;
                if (state == EntityState.Added)
                    context.People.Add(obj);
                context.SaveChanges();
            }
        }
    }
