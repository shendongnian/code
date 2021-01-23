            internal List<UserData> ConverToUserDataList(List<Training> TrainingList,List<Subject> AllSubjects )
        {
            List<UserData> userDataList = new List<UserData>();
            TrainingList.ForEach(t =>
                t.Subjects.ForEach(s =>
                    s.Users.ForEach(u =>
                      userDataList.Add(
                                 new UserData
                                 {
                                     UserId = u.UserId,
                                     FullName = u.FullName,
                                     SubjectNames = AllSubjects.Where(s2=>s2.Users.Contains(u)).Select(s2=>s2.Name).ToList(),
                                     TrainingNames = t.Name
                                 }
                                 ))));
            return userDataList;
        }
