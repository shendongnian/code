    public class MemberController : ControllerBase<Member>
    {
        public override void InsertOrUpdate(Member obj)
        {
            if (obj == null)
                throw new ArgumentException("Member");
            using (var context = new ChocDB())
            {
                var state = obj.Id == 0 ? EntityState.Added : EntityState.Modified;
                
                if (state == EntityState.Added)
                    context.People.Add(obj);
                context.SaveChanges();
            }
        }
    }
