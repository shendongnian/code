    //app start:
    var context = new ScheduleDatabaseEntities();
    context.Subjects.Load();
    private async void ButtonEvent(...)
    {
        int result = await FindSubjectId();
    }
    //button code
    private async Task<int?> FindSubjectId(string subject)
    {
            var findSubject = context.Subjects.Local.FirstOrDefault(a => a.Subject == subject);
            if (findSubject == null)
            {
                var subjectEntity = new Subjects { Subject= subject};
                context.Subjects.Add(subjectEntity);
                await context.SaveChangesAsync();
                return subjectEntity.SubjectId;
            }
            else
                return findSubject.SubjectId;
        }
